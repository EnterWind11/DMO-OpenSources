﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Write;
public class SendSYSWaitTime : IWritePacket
{

    public SendSYSWaitTime()
    {
    }
    public byte[] Construct()
    {
        using var writer = new PacketWriter();
        return writer.Finalize();
    }
}