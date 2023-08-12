using Yggdrasil.Interfaces.Models;
using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Read;

public class ServerListWritePacket : IWritePacket
{
    private readonly ClientDataEventArgs _clientDataEventArgs;
    private readonly List<DbCharacterModel> _characters;

    public ServerListWritePacket(ref ClientDataEventArgs clientDataEventArgs, List<DbCharacterModel> characters)
    {
        _clientDataEventArgs = clientDataEventArgs;
        _characters = characters;
    }

    public byte[] Construct()
    {
        using var writer = new PacketWriter();
        
        
        writer.Type(1701)
            .WriteByte(1)

            // Server
            .WriteInt(2)
            .WriteString("DEV Test Realm")
            .WriteByte(0)
            .WriteByte(0)
            .WriteByte((byte)_characters.Count)
            .WriteByte(1)
            .WriteByte(5)
            .WriteByte(5);

        return writer.Finalize();
    }
}