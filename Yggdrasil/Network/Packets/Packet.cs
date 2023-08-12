using System.Text;

namespace Yggdrasil.Server.Network;

public abstract class Packet
{
    protected readonly PacketWriter _packet;

    protected Packet() => this._packet = new PacketWriter();

    public byte[] ToArray() => this._packet.Finalize();

    public byte[] ToBuffer() => this._packet.PacketToBuffer();

    public string Visualize() => Packet.Visualize(this._packet.Finalize());

    public static string Visualize(byte[] buffer)
    {
        var stringBuilder1 = new StringBuilder();
        int num = (int)Math.Ceiling((double)buffer.Length / 16.0);
        for (int index1 = 0; index1 < num; ++index1)
        {
            var stringBuilder2 = new StringBuilder();
            for (int index2 = 0; index2 < 16; ++index2)
            {
                int index3 = index2 + index1 * 16;
                if (index3 < buffer.Length)
                {
                    stringBuilder1.Append(buffer[index3].ToString("X2"));
                    if (buffer[index3] > (byte)32 && buffer[index3] < (byte)126)
                        stringBuilder2.Append((char)buffer[index3]);
                    else
                        stringBuilder2.Append(".");
                }
                else
                {
                    stringBuilder1.Append("  ");
                    stringBuilder2.Append(" ");
                }

                stringBuilder1.Append(" ");
            }

            stringBuilder1.Append("    ");
            stringBuilder1.AppendLine(stringBuilder2.ToString());
        }

        return stringBuilder1.ToString();
    }
}