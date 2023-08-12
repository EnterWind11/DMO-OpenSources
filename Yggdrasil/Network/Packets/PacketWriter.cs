using System.Text;

namespace Yggdrasil.Server.Network;

public class PacketWriter : IDisposable
{
  private MemoryStream m_stream;
  private byte[] m_buffer;

  public PacketWriter()
  {
    m_stream = new MemoryStream();
    m_stream.Write(new byte[2], 0, 2);
  }

  public PacketWriter WriteInt(int value)
  {
    m_stream.Write(BitConverter.GetBytes(value), 0, 4);
    return this;
  }

  public PacketWriter WriteInt64(long value)
  {
    m_stream.Write(BitConverter.GetBytes(value), 0, 8);
    return this;
  }

  public PacketWriter WriteInt(int value, int pos)
  {
    m_stream.Seek((long)pos, SeekOrigin.Begin);
    m_stream.Write(BitConverter.GetBytes(value), 0, 4);
    return this;
  }

  public PacketWriter WriteByte(byte value)
  {
    m_stream.Write(BitConverter.GetBytes((short)value), 0, 1);
    return this;
  }

  public PacketWriter WriteShort(short value)
  {
    m_stream.Write(BitConverter.GetBytes(value), 0, 2);
    return this;
  }

  public PacketWriter WriteShort(short value, int pos)
  {
    m_stream.Seek((long)pos, SeekOrigin.Begin);
    m_stream.Write(BitConverter.GetBytes(value), 0, 2);
    return this;
  }

  public PacketWriter WriteUShort(ushort value)
  {
    m_stream.Write(BitConverter.GetBytes(value), 0, 2);
    return this;
  }

  public PacketWriter WriteString(string value)
  {
    byte[] bytes = Encoding.ASCII.GetBytes(value);
    m_stream.WriteByte((byte)bytes.Length);
    m_stream.Write(bytes, 0, bytes.Length);
    m_stream.WriteByte((byte)0);
    return this;
  }

  public PacketWriter WriteString(string value, int pos)
  {
    m_stream.Seek(pos, SeekOrigin.Begin);
    byte[] bytes = Encoding.ASCII.GetBytes(value);
    m_stream.WriteByte((byte)value.Length);
    m_stream.Write(bytes, 0, bytes.Length);
    m_stream.WriteByte((byte)0);
    return this;
  }

  public PacketWriter WriteBytes(byte[] buffer)
  {
    m_stream.Write(buffer, 0, buffer.Length);
    return this;
  }

  public PacketWriter Type(int type)
  {
    m_stream.Write(BitConverter.GetBytes(type), 0, 2);
    return this;
  }

  public PacketWriter WriteFloat(float value)
  {
    m_stream.Write(BitConverter.GetBytes(value), 0, 2);
    return this;
  }

  public PacketWriter WriteUInt(uint value)
  {
    m_stream.Write(BitConverter.GetBytes(value), 0, 4);
    return this;
  }

  public PacketWriter WriteUInt(uint value, int pos)
  {
    m_stream.Seek(pos, SeekOrigin.Begin);
    m_stream.Write(BitConverter.GetBytes(value), 0, 4);
    return this;
  }

  public PacketWriter WriteByte(uint value, int pos)
  {
    m_stream.Seek(pos, SeekOrigin.Begin);
    m_stream.Write(BitConverter.GetBytes(value), 0, 1);
    return this;
  }

  public byte[] Finalize()
  {
    WriteShort((short)0);
    byte[] array = m_stream.ToArray();
    byte[] bytes1 = BitConverter.GetBytes((short)array.Length);
    byte[] bytes2 = BitConverter.GetBytes((short)(array.Length ^ 6716));
    bytes1.CopyTo(array, 0);

    int index = array.Length - 2;
    bytes2.CopyTo(array, index);
    m_stream.Close();
    m_buffer = array;
    return m_buffer;
  }

  public byte[] PacketToBuffer() => m_buffer;

  public int Length => (int)m_stream.Length;
  public bool Disposed { get; private set; } = false;

  public void Dispose()
  {
    if (Disposed) return;

    Disposed = true;
    m_stream.Dispose();
  }
}