using Shared.Server.Game.Database;
using Yggdrasil.Server.Game.Managers;

namespace Yggdrasil.Server.Game.Entities;

public class Position
{
    public int Map { get; set; } = 3;
    public int X { get; set; } = 50;
    public int Y { get; set; } = 50;

    public Position()
    {
    }

    public Position(PortalDb portal) : this(portal.MapId, portal.UInts2[0], portal.UInts2[1])
    {
    }

    public Position(int map, int x, int y)
    {
        Map = map;
        X = x;
        Y = y;
    }

    public MapDb MapData => MapManager.MapDbs[Map];

    public string MapName => MapData.DisplayName;

    public Position Clone() => new(Map, X, Y);
}