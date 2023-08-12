using System.Text;

namespace Shared.Server.Game.Database;

public class MonsterDb
{
    //public static MonsterDb Load(BitReader reader, int index)
    //{
    //    reader.Seek(4 + index * 396);
    //    var monster = new MonsterDb
    //    {
    //        MonsterId = reader.ReadInt()
    //    };

    //    _ = reader.ReadInt();
    //    monster.Name = reader.ReadZString(Encoding.Unicode, 32);
        
    //    reader.Seek(336 + index * 396);
    //    monster.Level = reader.ReadShort();

    //    if (!MonsterListManager.Monsters.TryGetValue(monster.MonsterId, out var entity)) return monster;

    //    foreach (var m in entity.Monsters)
    //    {
    //        m.Entity.Level = monster.Level;
    //        m.Entity.Name = monster.Name;
    //    }

    //    return monster;
    //}
    
    public short Level { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public int MonsterId { get; set; }
}