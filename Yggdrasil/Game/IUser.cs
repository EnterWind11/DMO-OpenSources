using Yggdrasil.Server.Network;

namespace Yggdrasil.Server.Game;

public interface IUser
{
    IClient Client { get; set; }
}