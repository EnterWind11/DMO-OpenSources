using LoginServer;
using LoginServer.Packets.Read;
using System.Net.Sockets;
using System.Text;
using Yggdrasil.Enum;
using Yggdrasil.Server;
using Yggdrasil.Server.Network;

namespace LoginServer.Servers;

public sealed class LoginServers : ServerBase
{
    private readonly ILogger<LoginServers> _logger;
    private readonly IGrainFactory _grainFactory;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IEnumerable<IReadPacket> _readPackets;

    public LoginServers(ILogger<LoginServers> logger, IGrainFactory grainFactory, IHttpClientFactory clientFactory,
        IEnumerable<IReadPacket> readPackets) : base("0.0.0.0",
        7029)
    {
        _logger = logger;
        _grainFactory = grainFactory;
        _clientFactory = clientFactory;
        _readPackets = readPackets;

        OnConnect += OnConnectAsync;
        OnDisconnect += OnDisconnectAsync;
        DataReceived += OnDataReceivedAsync;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.Register(() => _logger.LogInformation("AuthenticationServer Stop requested"));

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("AuthenticationServer awaiting updates to process");
            await Task.Delay(10_000, stoppingToken);
        }
    }

    private async void OnConnectAsync(object sender, ClientEventArgs e)
    {
        _logger.LogInformation("Client Connected {@Client}", e.Client.ToString());
        e.Client.User = new LoginClient(e.Client);

        using var writer = new PacketWriter();
        e.Client.Handshake = (short)(DateTimeOffset.Now.ToUnixTimeSeconds() & 0xFFFF);
        writer.Type((int)ushort.MaxValue);
        writer.WriteShort(e.Client.Handshake);

        if (!e.Client.IsConnected)
            return;

        await e.Client.SendAsync(writer.Finalize());
    }

    private void OnDisconnectAsync(object sender, ClientEventArgs e)
    {
        var user = (LoginClient)e.Client.User;
        _logger.LogInformation("Client disconnected: {@Client}", e.Client.ToString());
    }

    private async void OnDataReceivedAsync(object sender, ClientDataEventArgs e, byte[] data)
    {
        using var reader = new PacketReader(data);

        //TODO Local onde faz o localizão do Packet Type e lança para classe responsavel pelo controle caso não seja localizado vai cair no switch type 
        if (_readPackets.Any(a => a.PacketType == (pLogin)reader.Type))
        {
            var packet = _readPackets.First(a => a.PacketType == (pLogin)reader.Type);
            var writePacket = await packet.PrepareAsync(reader, e); // Aguarde a conclusão da tarefa
            var result = writePacket.Construct(); // Chame o método Construct no resultado
            await e.Client.SendAsync(result); // Envie o resultado
            return;
        }
        switch (reader.Type)
        {
            case -3:
                break;
            default:
                _logger.LogInformation("");
                break;
        }
    }
}