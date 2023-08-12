using Shared.Server.Game.Database;

namespace Yggdrasil.Server.Game.Managers;

public class MapManager
{
    public static Dictionary<int, MapDb> MapDbs { get; } = new();

    public static void Load(string fileName)
    {
        //    if (MapDbs.Count > 0) return;

        //    using var stream = File.OpenRead(fileName);
        //    using var reader = new BitReader(stream);

        //    var num = reader.ReadInt();
        //    for (var index = 1; index < num; index++)
        //    {
        //        var map = MapDb.Load(reader, index);
        //        MapDbs.Add(map.MapId, map);
        //    }
    }
}