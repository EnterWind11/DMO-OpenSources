namespace Yggdrasil.Server.Game.Entities;

public class MonsterEntity
{
    public uint Model { get; set; }
    public string Name { get; set; } = "";
    public int Level { get; set; } = 1;
    public int Species { get; set; } = 31001;
    public short Size { get; set; } = 10000;
    public int MaxHp { get; set; } = 1000;
    public int Hp { get; set; } = 1000;
    public int Collision { get; set; }
    public Position Location { get; set; } = new();
    public int Handle { get; set; }

    public bool isAlive => Hp > 0;
    public IDisposable ResetTimer { get; set; }
    
    public int? Target { get; set; }
    public DateTime LastAttacked { get; set; } = DateTime.Now;

    public uint ProperModel() => (uint) (0 + (this.Species * 128 + 16) << 8);
}