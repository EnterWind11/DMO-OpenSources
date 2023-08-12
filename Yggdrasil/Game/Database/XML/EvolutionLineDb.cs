namespace Shared.Server.Game.Database;

public class EvolutionLineDb
{
    public int DigiId { get; set; }
    public int ILevel { get; set; }
    public short UShort1 { get; set; }
    public int[][] Line { get; set; }
    public int[] UInts1 { get; set; } = new int[11];
    public int[] UStats { get; set; } = new int[8];
    public int[] UInts2 { get; set; } = new int[5];
    public short[] UShorts1 { get; set; } = new short[4];
    public int[] UInts3 { get; set; } = new int[28];
    
    public EvoLevel Level => (EvoLevel) ILevel;
    
    public enum EvoLevel
    {
        Rookie = 1,
        Champion = 2,
        Ultimate = 3,
        Mega = 4,
        Burst = 5,
        Jogress = 6,
        RookieX = 7,
        ChampionX = 8,
        UltimateX = 9,
        MegaX = 10, // 0x0000000A
        BurstX = 11, // 0x0000000B
        JogressX = 12, // 0x0000000C
        Variant = 13, // 0x0000000D
        ZHybrid = 20, // 0x00000014
    }
}