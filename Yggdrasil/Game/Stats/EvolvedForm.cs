namespace Yggdrasil.Server.Game.Stats;

public class EvolvedForm
{
    public short[] UShorts1 { get; set; }
    public byte SkillPoints { get; set; }
    public byte[] SkillLevels { get; set; } = new byte[5];
    public byte SkillMaxLevel { get; set; }
    public byte UByte3 { get; set; }
    public byte[] Skills { get; set; } = new byte[5];
    public short UShort1 { get; set; }
    public int SkillExp { get; set; }
    public byte Unlocked { get; set; }
    public byte[] Bytes { get; set; }

    public byte[] ToArray()
    {
        using var memoryStream = new MemoryStream();
        memoryStream.WriteByte(0);
        memoryStream.WriteByte(0);
        memoryStream.WriteByte(0);
        memoryStream.WriteByte(4);
        memoryStream.WriteByte(this.Unlocked);
        memoryStream.WriteByte(0);
        memoryStream.WriteByte(0);
        memoryStream.WriteByte(0);
        memoryStream.WriteByte(0);
        memoryStream.WriteByte(SkillLevels[0]);
        memoryStream.WriteByte(SkillLevels[1]);
        memoryStream.WriteByte(SkillLevels[2]);
        memoryStream.WriteByte(SkillLevels[3]);
        memoryStream.WriteByte(SkillLevels[4]);
        memoryStream.WriteByte(SkillMaxLevel);
        memoryStream.WriteByte(SkillMaxLevel);
        memoryStream.WriteByte(SkillMaxLevel);
        memoryStream.WriteByte(SkillMaxLevel);
        memoryStream.WriteByte(SkillMaxLevel);
        return memoryStream.ToArray();
    }
}