using System.Text;
using Yggdrasil.Server.Game;
using Yggdrasil.Server.Network;

namespace LoginServer;

public class LoginClient : IUser
{
    public IClient Client { get; set; }
    
    public uint AccountId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string SecondaryPassword { get; set; }
    public int Characters { get; set; }
    public byte SubType;

    public LoginClient(IClient client)
    {
        Client = client;
    }

    public Task Handshake()
    {
        var totalSeconds = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        var num = (short)(Client.Handshake ^ 32321);

        using var writer = new PacketWriter();
        writer.Type(-2);
        writer.WriteShort(num);
        writer.WriteInt(totalSeconds);

        return Client.SendAsync(writer.Finalize());
    }
    private static string ExtractData(PacketReader packet)
    {
        int size = packet.ReadByte();
        string data = Encoding.ASCII.GetString(packet.ReadBytes(size)).Trim();
        if (size >= 1)
        {
            int sizenull = packet.ReadByte();
        }
        return data;
    }

    public static string ExtractGpu(PacketReader packet) => ExtractData(packet);
    public static string ExtractCpu(PacketReader packet) => ExtractData(packet);
    public static string ExtraUsertype(PacketReader packet) => ExtractData(packet);
    public static string ExtractPassword(PacketReader packet) => ExtractData(packet);
    public static string ExtractUserType(PacketReader packet) => ExtractData(packet);
    public static string ExtractUsername(PacketReader packet) => ExtractData(packet);
    public static string ExtractWindow(PacketReader packet) => ExtractData(packet);
    public static string ExtractVersion(PacketReader packet) => ExtractData(packet);
    public static string ExtractMD5Hash(PacketReader packet) => ExtractData(packet);
    public static byte[] EncodeToBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
}