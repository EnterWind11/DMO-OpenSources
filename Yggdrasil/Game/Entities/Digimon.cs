using Yggdrasil.Server.Game.Stats;

namespace Yggdrasil.Server.Game.Entities;

public class Digimon
{
    public uint DigiId { get; set; }
    public uint Model { get; set; }
    public int CharacterId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; } = 1;
    public Position Location { get; set; }
    public int Species { get; set; } = 31001;
    public short Handle { get; set; }
    public int CurrentForm { get; set; }
    public int Scale { get; set; } = 6;
    public short Size { get; set; } = 15_000;
    public int Exp { get; set; }
    public int LevelsUnlocked { get; set; }
    public short CloneAt { get; set; }
    public short CloneAtValue { get; set; }
    public short CloneBL { get; set; }
    public short CloneBlValue { get; set; }
    public short CloneCt { get; set; }
    public short CloneCtValue { get; set; }
    public short CloneEv { get; set; }
    public short CloneEvValue { get; set; }
    public short CloneHp { get; set; }
    public short CloneHpValue { get; set; }

    public DigimonStats Stats { get; set; } = new();
    public EvolvedForms Forms { get; set; } = new();

    public uint ProperModel() => (uint) (0 + (CurrentForm * 128 + 16) << 8);

    public byte ByteHandle => (byte) (Model & byte.MaxValue);
}