using Shared.Server.Game.Database;

namespace Yggdrasil.Server.Game.Managers;

public class PortalManager
{
    public static List<PortalClusterDb> PortalClusterDbs { get; set; } = new();

    public static PortalDb Find(int portalId) => PortalClusterDbs
        .First(a => a.PortalList.ContainsKey(portalId)).PortalList[portalId];

    public static void Load(string fileName)
    {
        if (PortalClusterDbs.Count > 0) return;

        using var stream = File.OpenRead(fileName);
        //using var reader = new BitReader(stream);

        //var num = reader.ReadInt();
        //for (var index = 0; index < num; ++index)
        //{
        //    try
        //    {
        //        var cluster = PortalClusterDb.Load(reader, index);
        //        PortalClusterDbs.Add(cluster);
        //    }
        //    catch
        //    {
                
        //    }
        //}
    }
}