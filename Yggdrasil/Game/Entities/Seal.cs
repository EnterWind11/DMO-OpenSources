namespace Yggdrasil.Server.Game.Entities;

public class Seal
{
    public short Id { get; set; }
    public ushort U1 { get; set; }
    public ushort U2 { get; set; }
    public short Amount { get; set; }

    public byte[] ToArray()
    {
        using var stream = new MemoryStream();
        stream.Write(BitConverter.GetBytes(Id), 0, 2);
        stream.Write(BitConverter.GetBytes(U1), 0, 2);
        stream.Write(BitConverter.GetBytes(U2), 0, 2);
        stream.Write(BitConverter.GetBytes(Amount), 0, 2);
        return stream.ToArray();
    }
}