using LoginServer.Packets.Write;
using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Read;

public class HandshakeReadPacket : IReadPacket
{
    public IWritePacket Prepare(PacketReader reader, ref ClientDataEventArgs args)
    {
        var totalSeconds = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        return new HandshakeWritePacket(totalSeconds, args.Client.Handshake);
    }

    public int PacketType => -1;
}