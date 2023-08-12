using Shared.Server.Game.Database;

namespace Yggdrasil.Server.Game.Managers;

public class MonsterManager
{
    public static Dictionary<int, MonsterDb> Monsters { get; set; } = new();

    public static void Load(string fileName)
    {
        if (Monsters.Count > 0) return;

        using var stream = File.OpenRead(fileName);
        //using var reader = new BitReader(stream);

        //var num = reader.ReadInt();
        //for (var index = 0; index < num; ++index)
        //{
        //    try
        //    {
        //        var monster = MonsterDb.Load(reader, index);
        //        Monsters.Add(monster.MonsterId, monster);
        //    }
        //    catch
        //    {
                
        //    }
        //}
    }
}