using Shared.Server;
using System.Net;
using System.Net.Sockets;
using Yggdrasil.Server.Game;
using Yggdrasil.Server.Game.Entities;

namespace Yggdrasil.Server.Network;

public sealed class Client : IClient
{
    public const int BufferSize = 16384;

    private readonly IServerBase _server;

    public ClientProgress State { get; set; } = ClientProgress.Auth;
    public bool IsConnected => Socket.Connected;
    public IPEndPoint? RemoteEndPoint => Socket.RemoteEndPoint as IPEndPoint;
    public IPEndPoint? LocalEndPoint => Socket.LocalEndPoint as IPEndPoint;
    
    public IUser User { get; set; }
    public short Handshake { get; set; }
    public Socket Socket { get; }
    public Character Tamer { get; set; }
    
    public byte[] RecvBuffer { get; } = new byte[BufferSize];

    public Client(IServerBase server, Socket socket)
    {
        _server = server ?? throw new ArgumentNullException(nameof(server));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
    }

    public IAsyncResult BeginReceive(AsyncCallback callback, object state) =>
        Socket.BeginReceive(RecvBuffer, 0, BufferSize, SocketFlags.None, callback, state);

    
    public async Task SendToAll(byte[] buffer)
    {
    }

    public async Task SendToPlayer(string name, byte[] buffer)
    {
     
    }

    public Task<int> SendAsync(byte[] buffer) => SendAsync(buffer, 0, buffer.Length, SocketFlags.None);

    public Task<int> SendAsync(byte[] buffer, SocketFlags flags) => SendAsync(buffer, 0, buffer.Length, flags);

    public Task<int> SendAsync(byte[] buffer, int start, int count) =>
        SendAsync(buffer, start, count, SocketFlags.None);

    public Task<int> SendAsync(byte[] buffer, int start, int count, SocketFlags flags)
        => _server.SendAsync(this, buffer, start, count, flags);

    public Task Disconnect() => _server.DisconnectAsync(this);

    public int EndReceive(IAsyncResult result) => Socket.EndReceive(result);
}