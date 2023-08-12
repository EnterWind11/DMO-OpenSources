using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Write;

public class HandshakeWritePacket : IWritePacket
{
    private readonly int _totalSeconds;
    private readonly int _handshake;

    public HandshakeWritePacket(int totalSeconds, int handshake)
    {
        _totalSeconds = totalSeconds;
        _handshake = handshake;
    }
    
    public byte[] Construct()
    {
        using var writer = new PacketWriter();
        
        short num1 = (short)(_handshake ^ 32321);
        writer.Type(-2)
            .WriteShort(num1).WriteInt(_totalSeconds);

        return writer.Finalize();
    }
}