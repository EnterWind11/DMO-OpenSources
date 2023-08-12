using Yggdrasil.Interfaces;
using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Read;

public class ServerListReadPacket : IReadPacket
{
    private readonly IGrainFactory _grainFactory;
    public int PacketType => 1701;
    
    public ServerListReadPacket(IGrainFactory grainFactory)
    {
        _grainFactory = grainFactory;
    }

    public IWritePacket Prepare(PacketReader reader, ref ClientDataEventArgs e)
    {
        var characters = _grainFactory
            .GetGrain<ICharacterManagerGrain>(((LoginClient)e.Client.User).AccountId)
            .FindAllAsync()
            .GetAwaiter()
            .GetResult();

        return new ServerListWritePacket(ref e, characters);
    }
}