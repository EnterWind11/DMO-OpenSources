using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Yggdrasil.Server.Network;

namespace Yggdrasil.Server;

public delegate void ClientEventHandler(object sender, ClientEventArgs e);

public delegate void ClientDataSendEventHandler(object sender, ClientDataEventArgs e);

public delegate void ClientDataReceiveEventHandler(object sender, ClientDataEventArgs e, byte[] data);

public interface IServerBase
{
    Task SendAllAsync(byte[] buffer);
    Task<int> SendAsync(IClient client, byte[] buffer, int start, int count, SocketFlags flags);
    Task DisconnectAsync(Client client);
    void Dispose();
}

public abstract class ServerBase : BackgroundService, IServerBase
{
    protected readonly string _bindIp;
    protected readonly int _port;
    private bool _dispoed;
    
    public event ClientEventHandler? OnConnect;
    public event ClientEventHandler? OnDisconnect;
    public event ClientDataReceiveEventHandler? DataReceived;
    public event ClientDataSendEventHandler? DataSent;

    protected Socket? Listener { get; private set; }

    public static ConcurrentDictionary<Socket, IClient> Clients { get; set;  } = new();

    protected ServerBase(string bindIp, int port)
    {
        _bindIp = bindIp;
        _port = port;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Listener.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, true);
        Listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
        Listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

        try
        {
            Listener.Bind(new IPEndPoint(IPAddress.Parse(_bindIp), _port));

        }
        catch (SocketException ex)
        {
            return StopAsync(cancellationToken);
        }

        Listener.Listen(10);
        Listener.BeginAccept(AcceptCallbackAsync, null);
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        Listener?.Close();
        Listener?.Dispose();
        return base.StopAsync(cancellationToken);
    }

    public async Task SendAllAsync(byte[] buffer)
    {
        foreach (var (_, client) in Clients)
        {
            if (!client.IsConnected) continue;
            await client.SendAsync(buffer);
        }
    }

    public virtual async Task<int> SendAsync(IClient client, byte[] buffer, int start, int count, SocketFlags flags)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client));
        if (buffer == null)
            throw new ArgumentNullException(nameof(buffer));

        var offset = 0;
        var length = buffer.Length;

        try
        {
            while (length > 0)
            {
                var size = await client.Socket.SendAsync(new ArraySegment<byte>(buffer, offset, length), flags);
                if (size > 0)
                    OnDataSent(new ClientDataEventArgs(client, buffer));
                length -= size;
                offset += size;
            }
        }
        catch (SocketException ex)
        {
            RemoveClient(client, true);
        }
        catch (Exception ex)
        {
            
        }

        return offset;
    }

    private async void AcceptCallbackAsync(IAsyncResult result)
    {
        if (!Listener.IsBound)
            return;

        var socket = Listener.EndAccept(result);
        var state = new Client(this, socket);
        Clients.TryAdd(socket, state);

        OnClientConnection(new ClientEventArgs(state));
        state.BeginReceive(ReceiveCallbackAsync, state);
        Listener.BeginAccept(AcceptCallbackAsync, null);
    }

    private async void ReceiveCallbackAsync(IAsyncResult result)
    {
        if (result.AsyncState is not Client asyncState)
            return;

        try
        {
            if (asyncState.EndReceive(result) > 0)
            {
                OnDataReceived(new ClientDataEventArgs(asyncState, asyncState.RecvBuffer));
                if (asyncState.IsConnected)
                    asyncState.BeginReceive(ReceiveCallbackAsync, asyncState);
                else RemoveClient(asyncState, true);
            }
            else RemoveClient(asyncState, true);
        }
        catch (SocketException ex)
        {
            RemoveClient(asyncState, true);
        }
        catch (Exception ex)
        {
            
        }
    }
    
    public async Task DisconnectAsync(Client client)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client));

        await client.Socket.DisconnectAsync(false);
        RemoveClient(client, true);
    }

    private void RemoveClient(IClient client, bool raiseEvent)
    {
        if (!(Clients.TryRemove(client.Socket, out _) & raiseEvent))
            return;

        OnClientDisconnection(new ClientEventArgs(client));
    }
    
    protected virtual void OnClientConnection(ClientEventArgs e) => OnConnect?.Invoke(this, e);

    protected virtual void OnClientDisconnection(ClientEventArgs e) => OnDisconnect?.Invoke(this, e);

    protected virtual void OnDataReceived(ClientDataEventArgs e) => DataReceived?.Invoke(this, e, e.Data);

    protected virtual void OnDataSent(ClientDataEventArgs e) => DataSent?.Invoke(this, e);
}