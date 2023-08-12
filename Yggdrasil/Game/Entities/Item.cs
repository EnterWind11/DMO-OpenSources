namespace Yggdrasil.Server.Game.Entities;

[Serializable]
public sealed class Item : IEquatable<Item>
{
    public static bool operator ==(Item left, Item right) => left.Equals(right);
    public static bool operator !=(Item left, Item right) => !(left.Equals(right));
    
    public uint Handle { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }
    public short[] Attributes { get; set; } = new short[4];
    
    public byte DigitalPower { get; set; }
    public byte DigitalRenewalNumber { get; set; }

    public short[] Stats = new short[4];
    public short[] StatValues = new short[4];
    
    public int Time { get; set; }
    
    // Unknowns
    public short Unknown { get; set; }
    public short Unknown1 { get; set; }
    public short Unknown2 { get; set; }
    public short Unknown3 { get; set; }
    public short Unknown5 { get; set; }
    public short Unknown10 { get; set; }
    public short Unknown11 { get; set; }
    public short Unknown12 { get; set; }
    public short Unknown13 { get; set; }
    public short Unknown18 { get; set; }
    public short Unknown19 { get; set; }
    public short Unknown20 { get; set; }
    public short Unknown21 { get; set; }
    public short Unknown22 { get; set; }

    public Item()
    {
    }

    public Item(int itemId)
    {
        var buffer = new byte[4];
        Random.Shared.NextBytes(buffer);
        Handle = BitConverter.ToUInt32(buffer, 0);
        ItemId = itemId;
    }

    public byte[] ToArray()
    {
        using var stream = new MemoryStream();

        if (ItemId <= 0)
        {
            stream.Write(new byte[68], 0, 68);
            return stream.ToArray();
        }
        
        stream.Write(BitConverter.GetBytes(ItemId), 0, 4);
        stream.Write(BitConverter.GetBytes(Amount), 0, 4);
        stream.Write(BitConverter.GetBytes(Unknown2), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown3), 4, 2);
        stream.Write(BitConverter.GetBytes((short)DigitalPower), 0, 1);
        stream.Write(BitConverter.GetBytes((short)DigitalRenewalNumber), 0, 1);
        stream.Write(BitConverter.GetBytes(Unknown1), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown5), 0, 2);
        stream.Write(BitConverter.GetBytes(Attributes[0]), 0, 2);
        stream.Write(BitConverter.GetBytes(Attributes[1]), 0, 2);
        stream.Write(BitConverter.GetBytes(Attributes[2]), 0, 2);
        stream.Write(BitConverter.GetBytes(Attributes[3]), 0, 2);
        stream.Write(BitConverter.GetBytes(Stats[0]), 0, 2);
        stream.Write(BitConverter.GetBytes(Stats[1]), 0, 2);
        stream.Write(BitConverter.GetBytes(Stats[2]), 0, 2);
        stream.Write(BitConverter.GetBytes(Stats[3]), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown10), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown11), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown12), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown13), 0, 2);
        stream.Write(BitConverter.GetBytes(StatValues[0]), 0, 2);
        stream.Write(BitConverter.GetBytes(StatValues[1]), 0, 2);
        stream.Write(BitConverter.GetBytes(StatValues[2]), 0, 2);
        stream.Write(BitConverter.GetBytes(StatValues[3]), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown18), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown19), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown21), 0, 2);
        stream.Write(BitConverter.GetBytes(Unknown22), 0, 2);
        stream.Write(BitConverter.GetBytes(Time), 0, 4);
        stream.Write(BitConverter.GetBytes(0), 0, 4);

        return stream.ToArray();
    }

    public bool Equals(Item? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Handle == other.Handle;
    }

    public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is Item other && Equals(other);

    public override int GetHashCode() => (int)Handle;
}