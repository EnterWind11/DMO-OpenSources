using Shared.Server.Game.Database;

namespace Yggdrasil.Server.Game.Managers;

public class MapNpcManager
{
    public static Dictionary<int, MapNpcDb> Npcs { get; } = new();

    public static void Load(string fileName)
    {
        if (Npcs.Count > 0) return;

        using var stream = File.OpenRead(fileName);
        //using var reader = new BitReader(stream);

        //var num = reader.ReadInt();
        //for (var index = 1; index < num; index++)
        //{
        //    var npc = MapNpcDb.Load(reader, index);
        //    Npcs.Add(npc.NpcId, npc);
        //}
    }
}