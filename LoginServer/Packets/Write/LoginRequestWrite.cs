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
    private string hashkey = "4A7B445B58427A254F324D49557F595329542D7E5F6946623B673E2820237570386D5E452A743121262C7D5C722F34774071333C43223D3948646C7947512E5A766873273F6E562B52246135574C4B6030657C366B6A3A785D504E3766416F24625E215B77704E4C614F752124682C3A366641697C3C59415D22692A25455052615435783D6C5939492B6633274D37384C74333344365B2A575D382F3866622925522D70743A2F3F652E3B34667D623F712B6976772422277F51754D402D6E71422C7043254C5532433D644D4E6C3B572670717E56394B255E364B483C46455D4F212C7778592E7F222E435D2F28645057706A4D6D65785E35473C23435749684450686B2036617B6451393138486656446953284A7C3A5E6046785C7F5B34384536623441";
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