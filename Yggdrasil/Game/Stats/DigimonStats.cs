namespace Yggdrasil.Server.Game.Stats;

public class DigimonStats
{
    public static DigimonStats operator *(DigimonStats stats, short size)
    {
        var multiplication = size;
        
        var cloned = (DigimonStats)stats.MemberwiseClone();
        cloned.Hp = cloned.MaxHp = (short)(cloned.Hp * multiplication);
        cloned.Ds = cloned.MaxDs = (short)(cloned.Ds * multiplication);
        cloned.At = (short)(cloned.At * multiplication);
        cloned.De = (short)(cloned.De * multiplication);
        cloned.Ms = (short)(cloned.Ms * multiplication);
        cloned.Cr = (short)(cloned.Cr * multiplication);
        return cloned;
    }
    
    private short _baseHp = 100;
    private short _baseDs = 100;

    public short MaxHp { get; set; } = 100;
    public short MaxDs { get; set; } = 100;
    public short At { get; set; } = 1;
    public short De { get; set; } = 1;
    public short Ht { get; set; }
    public short Ev { get; set; } = 10;
    public short Cr { get; set; }
    public short Ar { get; set; } = 50;
    public short Bl { get; set; }
    public short As { get; set; } = 1000;
    public short Ms { get; set; } = 550;
    public short UStat { get; set; } = 80;
    public short Intimacy { get; set; }

    public short Hp
    {
        get => _baseHp;
        set
        {
            if (value >= MaxHp)
                value = MaxHp;
            if (value <= 0)
                value = 0;
            _baseHp = value;
        }
    }
    
    public short Ds
    {
        get => _baseDs;
        set
        {
            if (value >= MaxDs)
                value = MaxDs;
            if (value <= 0)
                value = 0;
            _baseDs = value;
        }
    }

    public DigimonStats Max()
    {
        MaxHp = MaxDs = Ds = Hp = short.MaxValue;
        At = De = Ht = Ev = Cr = 10000;
        Ms = 1200;
        As = 5;
        Intimacy = 100;
        return this;
    }
}