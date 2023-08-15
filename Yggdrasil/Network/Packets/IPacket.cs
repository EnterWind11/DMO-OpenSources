using Yggdrasil.Enum;

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

    pLogin PacketType { get; }

    Task<IWritePacket> PrepareAsync(PacketReader reader, ClientDataEventArgs args); // Método assíncrono
}

public interface IWritePacket : IPacket
{
    Direction IPacket.Type => Direction.Write;

    byte[] Construct();
}