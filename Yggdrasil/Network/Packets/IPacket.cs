namespace Yggdrasil.Server.Network;

public enum Direction
{
    Read,
    Write
}

public interface IPacket
{
    Direction Type { get; }
}

public interface IReadPacket : IPacket
{
    Direction IPacket.Type => Direction.Read;
    
    int PacketType { get; }
    
    IWritePacket Prepare(PacketReader reader, ref ClientDataEventArgs args);
}

public interface IWritePacket : IPacket
{
    Direction IPacket.Type => Direction.Write;

    byte[] Construct();
}