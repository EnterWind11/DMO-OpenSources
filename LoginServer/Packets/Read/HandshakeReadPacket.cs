using LoginServer.Packets.Write;
using Yggdrasil.Enum;
using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Read;

public class HandshakeReadPacket : IReadPacket
{
    public async Task<IWritePacket> PrepareAsync(PacketReader reader, ClientDataEventArgs args)
    {
        var totalSeconds = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        return new HandshakeWritePacket(totalSeconds, args.Client.Handshake);
    }

    public pLogin PacketType => pLogin.SYS_HANDSHAKE_RES;
}