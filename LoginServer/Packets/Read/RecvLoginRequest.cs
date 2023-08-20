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
    public class RecvLoginRequest : IReadPacket
    {
        private readonly IGrainFactory _grainFactory; // Adicionar a fábrica de grãos

        public RecvLoginRequest(IGrainFactory grainFactory) // Construtor para aceitar a fábrica de grãos
        {
            _grainFactory = grainFactory;
        }
        public pLogin PacketType => pLogin.Request;

        public async Task<IWritePacket> PrepareAsync(PacketReader reader, ClientDataEventArgs e)
        {

            uint version = reader.ReadUInt();
            var userType = LoginClient.ExtractUserType(reader);
            var username = LoginClient.ExtractUsername(reader);
            var password = LoginClient.ExtractPassword(reader);
            var cpu = LoginClient.ExtractCpu(reader);
            var gpu = LoginClient.ExtractGpu(reader);
            var memoriaram = reader.ReadInt() / 1000;
            var Windows = LoginClient.ExtractWindow(reader);
            var VersionClient = LoginClient.ExtractVersion(reader);

            var character = await _grainFactory.GetGrain<IAccountManagerGrain>(0)
                    .FindAsync(username, password);

            if (character == null)
                character = await _grainFactory.GetGrain<IAccountManagerGrain>(0)
                    .CreateAsync(username, password);

            var loginClient = (LoginClient)e.Client.User;
            //loginClient.UniqueId = character!.UniqueId;
            loginClient.AccountId = character!.AccountId;
            loginClient.SecondaryPassword = character!.SecurityCode;
            loginClient.Characters = (await _grainFactory
                .GetGrain<ICharacterManagerGrain>(character!.AccountId)
                .FindAllAsync()).Count;
            e.Client.SendAsync((new HashCheck()).ToArray());
            return new LoginRequestWrite(0, 1);
        }
    }
}