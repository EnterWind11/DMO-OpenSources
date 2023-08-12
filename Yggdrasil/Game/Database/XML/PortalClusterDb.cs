namespace Shared.Server.Game.Database;

public class PortalClusterDb
{
    //public static PortalClusterDb Load(BitReader reader, int index)
    //{
    //    var cluster = new PortalClusterDb
    //    {
    //        Count = reader.ReadInt()
    //    };

    //    for (var i = 0; i < cluster.Count; ++i)
    //    {
    //        var portal = new PortalDb
    //        {
    //            PortalId = reader.ReadInt()
    //        };
    //        reader.ReadInt();

    //        for (var j = 0; j < portal.UInts1.Length; ++j)
    //            portal.UInts1[j] = reader.ReadInt();
    //        portal.MapId = reader.ReadInt();
    //        for (var j = 0; j < portal.UInts2.Length; ++j)
    //            portal.UInts2[j] = reader.ReadInt();

    //        cluster.PortalList.TryAdd(portal.PortalId, portal);
    //    }

    //    return cluster;
    //}
    
    public int Count { get; set; }
    public Dictionary<int, PortalDb> PortalList { get; set; } = new();

    public PortalDb this[int index]
    {
        get => PortalList[index];
    }
}