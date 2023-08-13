using Yggdrasil.Interfaces;
using Yggdrasil.Server.Network;

namespace LoginServer.Packets.Read
{
    // Define a classe ServerListReadPacket, que lê a lista de servidores.
    public class ServerListReadPacket : IReadPacket
    {
        private readonly IGrainFactory _grainFactory; // Interface para criar grãos (componentes distribuídos).
        public int PacketType => 1701; // Define o tipo de pacote. Cada pacote tem um identificador único.

        // Construtor que recebe uma fábrica de grãos, que será usada para obter os grãos necessários.
        public ServerListReadPacket(IGrainFactory grainFactory)
        {
            _grainFactory = grainFactory;
        }

        // Método para preparar o pacote de leitura. Ele lê os dados do pacote e retorna um pacote de escrita.
        public IWritePacket Prepare(PacketReader reader, ref ClientDataEventArgs e)
        {
            // Obtém o grão para gerenciar os personagens usando a interface ICharacterManagerGrain.
            // Usa o AccountId do usuário atual para encontrar todos os personagens associados.
            var characters = _grainFactory
                .GetGrain<ICharacterManagerGrain>(((LoginClient)e.Client.User).AccountId)
                .FindAllAsync()
                .GetAwaiter()
                .GetResult();

            // Retorna um novo pacote de escrita ServerListWritePacket, que inclui a lista de servidores e personagens.
            return new ServerListWritePacket(ref e, characters);
        }
    }
}