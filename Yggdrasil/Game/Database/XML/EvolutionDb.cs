namespace Shared.Server.Game.Database;

public class EvolutionDb
{
    public static EvolutionDb Load(BinaryReader reader, int index, ref int num1)
    {
        var evolution = new EvolutionDb();
        evolution.DigiId = reader.ReadInt32();

        var num3 = num1 + 4;
        reader.ReadInt32();
        var num4 = num3 + 4;
        evolution.Digivolutions = reader.ReadInt32();
        num1 = num4 + 4;

        for (var i = 0; i < evolution.Digivolutions; ++i)
        {
            var line = new EvolutionLineDb
            {
                DigiId = reader.ReadInt32()
            };

            var num5 = num1 + 4;
            line.ILevel = reader.ReadInt16();
            num1 = num5 + 4;
            line.UShort1 = reader.ReadInt16();
            line.Line = new int[2][]
            {
                new int[10], new int[10]
            };

            for (var j = 0; j < 10; ++j)
            {
                line.Line[0][j] = reader.ReadInt32();
                line.Line[1][j] = reader.ReadInt32();
            }

            line.UInts1 = new int[11];
            for (int index4 = 0; index4 < 11; ++index4)
                line.UInts1[index4] = reader.ReadInt32();
            line.UStats = new int[8];
            for (int index5 = 0; index5 < 8; ++index5)
                line.UStats[index5] = reader.ReadInt32();
            line.UInts2 = new int[5];
            for (int index6 = 0; index6 < 5; ++index6)
                line.UInts2[index6] = reader.ReadInt32();
            line.UShorts1 = new short[4];
            for (int index7 = 0; index7 < 4; ++index7)
                line.UShorts1[index7] = reader.ReadInt16();
            line.UInts3 = new int[34];
            for (int index8 = 0; index8 < 34; ++index8)
                line.UInts3[index8] = reader.ReadInt32();
            
            evolution.Evolutions.Add(line);
        }

        return evolution;
    }
    
    public int DigiId { get; set; }
    public int Digivolutions { get; set; }
    public List<EvolutionLineDb> Evolutions { get; set; } = new();
}