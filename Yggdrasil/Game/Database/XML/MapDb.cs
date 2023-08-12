using System.Diagnostics;
using System.Text;

namespace Shared.Server.Game.Database;

[DebuggerDisplay("{Name}|{DisplayName} -> ({MapId},{MapLocation})")]
public class MapDb
{
    //public static MapDb Load(BitReader reader, int index)
    //{
    //    var map = new MapDb
    //    {
    //        MapId = reader.ReadInt()
    //    };

    //    var nameLength = reader.ReadInt();
    //    var nameBytes = reader.ReadBytes(nameLength);
    //    map.Name = Encoding.ASCII.GetString(nameBytes).Trim();

    //    var locationLength = reader.ReadInt();
    //    var locationBytes = reader.ReadBytes(locationLength);
    //    map.MapLocation = Encoding.ASCII.GetString(locationBytes).Trim();

    //    var soundLength = reader.ReadInt();
    //    var soundBytes = reader.ReadBytes(soundLength);
    //    map.MapSound = Encoding.ASCII.GetString(soundBytes).Trim();

    //    map.MapNumbers = new[] { reader.ReadInt(), reader.ReadInt() };

    //    var displayNameLength = reader.ReadInt();
    //    map.DisplayName = reader.ReadZString(Encoding.Unicode, displayNameLength).Trim();
    //    reader.Seek((int)(reader.InnerStream.BaseStream.Position - 4));

    //    var testLength = reader.ReadInt();
    //    map.Test = new ushort[testLength];

    //    for (var i = 0; i < testLength; ++i)
    //        map.Test[i] = reader.ReadUShort();

    //    var temp1 = reader.ReadShort();
    //    var temp2 = reader.ReadInt();
    //    var temp4 = reader.ReadInt();
    //    var temp5 = reader.ReadShort();
    //    var temp6 = reader.ReadShort();
    //    var temp7 = reader.ReadShort();
    //    var temp8 = reader.ReadInt();
    //    return map;
    //}
    
    public ushort[] Test { get; set; }
    public int MapId { get; set; }
    public string MapLocation { get; set; }
    
    public int[] MapNumbers { get; set; }
    public string MapSound { get; set; }
    
    public string Name { get; set; }
    public string DisplayName { get; set; }
    
    public int[] Handlers { get; set; }
}