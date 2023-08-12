namespace Shared.Server.Game.Database;

public class MapNpcDb
{
    //public static MapNpcDb Load(BitReader reader, int index)
    //{
    //    var npc = new MapNpcDb
    //    {
    //        NpcId = reader.ReadInt(),
    //        MapId = reader.ReadInt(),
    //        X = reader.ReadInt(),
    //        Y = reader.ReadInt()
    //    };

    //    _ = reader.ReadShort();
    //    _ = reader.ReadShort();
    //    return npc;
    //}
    
    public int MapId { get; set; }
    public int NpcId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}