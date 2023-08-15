using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Write;
public class LoginRequestWrite : IWritePacket
{
    private readonly int _nResult;
    private readonly byte _nSubType;

    public LoginRequestWrite(int nResult, byte nSubType)
    {
        _nResult = nResult;
        _nSubType = nSubType;
    }
    public byte[] Construct()
    {
        using var writer = new PacketWriter();
        writer.Type(3301)
            .WriteInt(_nResult)
            .WriteByte(_nSubType);
        return writer.Finalize();
    }
}
public sealed class HashCheck : Packet
{
    private string hashkey = "572129263D774C244A782D623E386041315147255D2F5E58487A653749286A76303F73796B455F4F752E7467686C2B3A5B2A546E2C42207C6D36595C72555669707D337B4E35392340464453344366225A3B7E64527F504D4B617127323C6F6B2062592A7A2523326F584A2C2066564C4A5A257B696C3F643440416D5F70223C4A626F4E74404D506F71355F4D647F6C383639704173506E573555443867376A6D226F3E654B2D503D7C71387A7F4C463E2C7A5F6E5B727A3C26344F46332268543E3B6B644F6449604373463228556A2A773D6D4C4F4C7837234E21673D3C426C223C617C575428555979646A76662E552968774E237453726E4638434A72767324726A674F6A202631285E3C545C43375F347362734C2B606C61674033205A6C434D6B423E4F2039526C32626E412A722A2C39253C28363D725E6628655857432752";
    public HashCheck()
    {
        _packet.Type(10003)
            .WriteShort((short)(hashkey.Length / 2))
       .WriteBytes(ToByteArray(hashkey));

    }
    public static byte[] ToByteArray(string hexString)
    {
        int NumberChars = hexString.Length;
        byte[] bytes = new byte[NumberChars / 2];

        for (int i = 0; i < NumberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);

        return bytes;
    }
}