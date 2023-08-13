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
