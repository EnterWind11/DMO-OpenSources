using Yggdrasil.Server.Game.Entities;

namespace Shared.Server.Game.Database;

public class MapMonsterDb
{
    //public static MapMonsterDb Load(BitReader reader, int index)
    //{
    //    var mapMonster = new MapMonsterDb
    //    {
    //        MonsterId = reader.ReadInt(),
    //        Count = reader.ReadInt()
    //    };

    //    for (var i = 0; i < mapMonster.Count; ++i)
    //    {
    //        mapMonster.Monsters = new List<Monster>(mapMonster.Count);
    //        var monster = new Monster
    //        {
    //            MapId = new int[mapMonster.Count],
    //            MonsterCount = new int[mapMonster.Count]
    //        };

    //        monster.MapId[i] = reader.ReadInt();
    //        monster.MonsterCount[i] = reader.ReadInt();
    //        monster.MonsterSpecies = new int[monster.MonsterCount[i]];
    //        monster.Position = new int[2][]
    //        {
    //            new int[monster.MonsterCount[i]],
    //            new int[monster.MonsterCount[i]]
    //        };

    //        for (var j = 0; j < monster.MonsterCount[i]; ++j)
    //        {
    //            var num2 = reader.ReadInt();
    //            var entity = new MonsterEntity();
                
    //            monster.MonsterSpecies[j] = reader.ReadInt();
    //            monster.Position[0][j] = reader.ReadInt();
    //            monster.Position[1][j] = reader.ReadInt();

    //            entity.Species = monster.MonsterSpecies[j];
    //            entity.Location.Map = num2;
    //            entity.Location.X = monster.Position[0][j];
    //            entity.Location.Y = monster.Position[1][j];
    //            entity.Handle = 64999 + index + Random.Shared.Next(1, 5000);
    //            entity.Collision = reader.ReadInt();
    //            reader.ReadInt();
    //            reader.ReadInt();
    //            reader.ReadInt();
    //            reader.ReadInt();
    //            reader.ReadInt();
    //            reader.ReadInt();
    //            reader.ReadInt();

    //            monster.Entity = entity;
    //            mapMonster.Monsters.Add(monster);
    //        }
    //    }

    //    return mapMonster;
    //}
    
    public int MonsterId { get; set; }
    public int Count { get; set; }
    public List<MapMonsterDb.Monster> Monsters { get; set; }

    public class Monster
    {
        public int[] MapId { get; set; }
        public int[] MonsterSpecies { get; set; }
        public int MonsterId { get; set; }
        public int[] MonsterCount { get; set; }
        public int[][] Position { get; set; }
        public MonsterEntity Entity { get; set; }
    }
}