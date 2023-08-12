using Shared.Server.Game.Database;

namespace Yggdrasil.Server.Game.Managers;

public static class EvolutionManager
{
    public static Dictionary<int, EvolutionDb> Evolutions { get; } = new();

    public static void Load(string fileName)
    {
        var num1 = 0;
        if (Evolutions.Count > 0) return;

        using var stream = File.OpenRead(fileName);
        //using var reader = new BitReader(stream);

        //var length = reader.ReadInt();
        //for (var i = 0; i < length; ++i)
        //{
        //    var evolution = EvolutionDb.Load(reader, i, ref num1);
        //    Evolutions.Add(evolution.DigiId, evolution);
        //}
    }
}