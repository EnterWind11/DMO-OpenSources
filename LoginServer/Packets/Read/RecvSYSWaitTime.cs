using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yggdrasil.Server.Network;
using Yggdrasil.Database.Login; // Certifique-se de importar o namespace correto
using Yggdrasil.Server.Game.Entities;
using Yggdrasil.Database;
using Yggdrasil.Enum;
using Orleans.Serialization.Buffers;
using LoginServer.Packets.Write;
using System.Data;
using Yggdrasil.Interfaces;

namespace LoginServer.Packets.Read
{
    public class RecvSYSWaitTime : IReadPacket
    {
        private readonly IGrainFactory _grainFactory; // Adicionar a fábrica de grãos

        public RecvSYSWaitTime(IGrainFactory grainFactory) // Construtor para aceitar a fábrica de grãos
        {
            _grainFactory = grainFactory;
        }
        public pLogin PacketType => pLogin.SYS_ALIVE;

        public async Task<IWritePacket> PrepareAsync(PacketReader reader, ClientDataEventArgs e)
        {
            return new SendSYSWaitTime();
        }
    }
}