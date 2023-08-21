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

            var g_nNetVersion = reader.ReadUInt();
            var GetUserType = LoginClient.ExtractUserType(reader);
            var userID = LoginClient.ExtractUsername(reader);
            var userPass = LoginClient.ExtractPassword(reader);
            var szCpuName = LoginClient.ExtractCpu(reader);
            var szGpuName = LoginClient.ExtractGpu(reader);
            var nPhyMemory = reader.ReadInt()/1024;
            var szOS = LoginClient.ExtractWindow(reader);
            var szDxVersion = LoginClient.ExtractVersion(reader);

            var character = await _grainFactory.GetGrain<IAccountManagerGrain>(0)
                    .FindAsync(userID, userPass);

            if (character == null)
                character = await _grainFactory.GetGrain<IAccountManagerGrain>(0)
                    .CreateAsync(userID, userPass);

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