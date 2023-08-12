using System.Diagnostics;
using System.Text;
using Yggdrasil.Server.Game.Stats;

namespace Shared.Server.Game.Database;

[DebuggerDisplay("{Species}|{Model} -> {Name}")]
public class DigimonDb
{
    //public static DigimonDb Load(BinaryReader reader, int index)
    //{
    //    reader.(4 + index * 572);

    //    var data = new DigimonDb
    //    {
    //        Species = reader.ReadInt32(),
    //        Model = reader.ReadInt32()
    //    };

    //    reader.Seek(140 + index * 572);
    //    data.Name = reader.ReadZString(Encoding.ASCII);

    //    reader.Seek(336 + index * 572);
    //    data.EvolutionType = reader.ReadInt32();
    //    data.AttributeType = reader.ReadInt32();
    //    data.Families = new[] { reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32() };
    //    data.NatureType = reader.ReadInt32();
    //    data.Natures = new[] { reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32() };
    //    data.BaseLevel = reader.ReadInt32();

    //    reader.Seek(376 + index * 572);
    //    data.BaseStats = new DigimonStats
    //    {
    //        MaxHp = reader.ReadInt16(),
    //        MaxDs = reader.ReadInt16(),
    //        De = reader.ReadInt16(),
    //        Ev = reader.ReadInt16(),
    //        Ms = reader.ReadInt16(),
    //        Cr = reader.ReadInt16(),
    //        At = reader.ReadInt16(),
    //        As = reader.ReadInt16(),
    //        Ar = reader.ReadInt16(),
    //        Ht = reader.ReadInt16(),
    //        Bl = 0
    //    };
    //    data.UShort1 = reader.ReadInt16();
        
    //    reader.Skip(4);
    //    var skill1 = reader.ReadInt32();
    //    var temp = reader.ReadInt32();
    //    var skill2 = reader.ReadInt32();
    //    reader.Skip(4);
    //    var skill3 = reader.ReadInt32();
    //    reader.Skip(4);
    //    var skill4 = reader.ReadInt32();
    //    reader.Skip(4);
    //    var skill5 = reader.ReadInt32();
    //    return data;
    //}
    
    public int Species { get; set; }
    public int Model { get; set; }
    public int EvolutionType { get; set; }
    public int AttributeType { get; set; }
    public int NatureType { get; set; }
    public int[] Families { get; set; } = new int[3];
    public int[] Natures { get; set; } = new int[3];
    public int BaseLevel { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    
    public DigimonStats BaseStats { get; set; }
    
    public short UShort1 { get; set; }

    public int[] Skills { get; set; } = new int[5];

    public DigimonStats Stats(short size) => BaseStats * size;
}