using System.Net;
using System.Net.Sockets;
using Yggdrasil.Server.Game;
using Yggdrasil.Server.Game.Entities;

namespace Yggdrasil.Server.Network;

public enum ClientProgress
{
    Auth,
    Char,
    Game
}

public interface IClient
{
    ClientProgress State { get; set; } 
    
    bool IsConnected { get; }

    IPEndPoint? RemoteEndPoint { get; }

    IPEndPoint? LocalEndPoint { get; }

    IUser User { get; set; }

    short Handshake { get; set; }

    Socket Socket { get; }

    Character Tamer { get; set; }

    Task<int> SendAsync(byte[] buffer);

    Task SendToAll(byte[] buffer);

    Task SendToPlayer(string name, byte[] buffer);

    Task<int> SendAsync(byte[] buffer, SocketFlags flags);

    Task<int> SendAsync(byte[] buffer, int start, int count);

    Task<int> SendAsync(byte[] buffer, int start, int count, SocketFlags flags);

    Task Disconnect();
}