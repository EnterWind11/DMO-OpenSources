using System.Text;

namespace Yggdrasil.Server.Network;

public class PacketReader : IDisposable
{
  private readonly MemoryStream _packet;

  public int Length { get; }

  public int Type { get; }

  public PacketReader(MemoryStream stream)
  {
    _packet = stream;
  }

  public PacketReader(byte[] buffer)
  {
    _packet = new MemoryStream(buffer);
    Length = ReadShort();
    Type = ReadShort();
    _packet.Seek((long)(Length - 2), SeekOrigin.Begin);
    if ((int)ReadShort() != (Length ^ 6716))
      throw new Exception("Invalid packet checksum");
    int length1 = buffer.Length;
    int length2 = Length;
    _packet.Seek(4L, SeekOrigin.Begin);
  }

  public void Seek(long position) => _packet.Seek(position, SeekOrigin.Begin);

  public void Skip(long bytes) => _packet.Seek(bytes, SeekOrigin.Current);

  public int ReadInt()
  {
    byte[] buffer = new byte[4];
    _packet.Read(buffer, 0, 4);
    return BitConverter.ToInt32(buffer, 0);
  }

  public int ReadScan()
  {
    byte[] buffer = new byte[15];
    _packet.Read(buffer, 0, 15);
    for (int index = 0; index < 15; ++index)
      Console.WriteLine((int)buffer[index]);
    return BitConverter.ToInt32(buffer, 0);
  }

  public byte ReadByte()
  {
    byte[] buffer = new byte[1];
    _packet.Read(buffer, 0, 1);
    return buffer[0];
  }

  public short ReadShort()
  {
    byte[] buffer = new byte[2];
    _packet.Read(buffer, 0, 2);
    return BitConverter.ToInt16(buffer, 0);
  }

  public ushort ReadUShort()
  {
    byte[] buffer = new byte[2];
    _packet.Read(buffer, 0, 2);
    return BitConverter.ToUInt16(buffer, 0);
  }

  public float ReadFloat()
  {
    byte[] buffer = new byte[4];
    _packet.Read(buffer, 0, 4);
    return BitConverter.ToSingle(buffer, 0);
  }

  public string ReadString()
  {
    int count = _packet.ReadByte();
    byte[] numArray = new byte[count];
    _packet.Read(numArray, 0, count);
    return Encoding.ASCII.GetString(numArray).Trim();
  }

  public string ReadZString()
  {
    var stringBuilder = new StringBuilder();
    while (_packet.CanRead)
    {
      int num = _packet.ReadByte();
      if (num != 0)
        stringBuilder.Append((char)num);
      else
        break;
    }

    return stringBuilder.ToString();
  }

  public byte[] ReadBytes(int len)
  {
    byte[] buffer = new byte[len];
    _packet.Read(buffer, 0, len);
    return buffer;
  }

  public uint ReadUInt()
  {
    byte[] buffer = new byte[4];
    _packet.Read(buffer, 0, 4);
    return BitConverter.ToUInt32(buffer, 0);
  }

  public override string ToString() => Packet.Visualize(ToArray());

  public byte[] ToArray() => _packet.ToArray();

  public void Dispose()
  {
    _packet.Close();
    _packet.Dispose();
  }
}

public static class PacketReaderExtensions
{
  public static void Save(this PacketReader reader)
  {
    var path = $@"C:\data\packets";
    try
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      using var fileStream =
        new FileStream(Path.Combine(path, $@"{reader.Type}_{DateTime.Now:MM-dd-yyyy_HH-mm-ss}.hex"),
          FileMode.OpenOrCreate);
      fileStream.Write(reader.ToArray());
      fileStream.Close();
    }
    catch
    {
      
    }
  }
}