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

namespace LoginServer.Packets.Read
{
    public class RecvLoginRequest : IReadPacket
    {
        public int PacketType => 3301;

        public IWritePacket Prepare(PacketReader reader, ref ClientDataEventArgs args)
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

            // Cria uma instância da classe BaseDB
            BaseDB db = new BaseDB();

            // Criar uma instância da classe UserAuthenticationQuery, passando a instância de BaseDB
            UserAuthenticationQuery userAuthQuery = new UserAuthenticationQuery(db);

            // Chamar o método Validate
            UserValidationResult validationResult = userAuthQuery.Validate(username, password);
            // Verificar o resultado
            if (validationResult.Status == LoginRequestStatusEnum.Success)
            {
                var loginClient = (LoginClient)args.Client.User;
                loginClient.AccountId = Convert.ToUInt32(validationResult.UserData["AccountId"]);
                loginClient.Username = Convert.ToString(validationResult.UserData["username"]);
                loginClient.SecondaryPassword = Convert.ToString(validationResult.UserData["2pass"]);
                loginClient.SubType = Convert.ToByte(validationResult.UserData["SubType"]);
                args.Client.SendAsync((new HashCheck()).ToArray());
                return new LoginRequestWrite(0, loginClient.SubType);
            }
            else
            {

            }

            return null; // Altere isso de acordo com a necessidade.
        }
    }
}