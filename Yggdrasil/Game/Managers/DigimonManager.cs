using Shared.Server.Game.Database;

namespace Yggdrasil.Server.Game.Managers;

public class DigimonManager
{
    public static Dictionary<int, DigimonDb> DigimonDbs { get; } = new Dictionary<int, DigimonDb>();

    public static uint GetModel(uint model) => (uint) (model + (ulong) Random.Shared.Next(1, byte.MaxValue));
    
    public static int FindEvolutionType(int species) =>
        DigimonDbs.ContainsKey(species) ? DigimonDbs[species].EvolutionType : -1;

    public static void Load(string fileName)
    {
        if (DigimonDbs.Count > 0) return;

        using var stream = File.OpenRead(fileName);
        //using var reader = new BitReader(stream);

        //var num = reader.ReadInt();
        //for (var index = 1; index < num; index++)
        //{
        //    var digimon = DigimonDb.Load(reader, index);
        //    DigimonDbs.Add(digimon.Species, digimon);
        //}
    }
}