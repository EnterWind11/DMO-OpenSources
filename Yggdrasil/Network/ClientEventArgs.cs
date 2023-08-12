namespace Yggdrasil.Server.Network;

public class ClientEventArgs : EventArgs
{
    public IClient Client { get; }

    public ClientEventArgs(IClient client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public override string ToString() =>
        Client.RemoteEndPoint == null ? "Not Connected" : Client.RemoteEndPoint.ToString();
}

public sealed class ClientDataEventArgs : ClientEventArgs
{
    public byte[] Data { get; }
    
    public ClientDataEventArgs(IClient client, byte[] data) : base(client)
    {
        Data = data;
    }

    public override string ToString() =>
        Client.RemoteEndPoint == null
            ? $"Not Connected: {Data.Length} bytes"
            : $"{(object)this.Client.RemoteEndPoint}: {Data.Length} bytes";
}