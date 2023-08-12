namespace Shared.Server.Game.Database;

public class PortalDb
{
    public int PortalId { get; set; }
    public int MapId { get; set; }

    public int[] UInts1 { get; set; } = new int[4];
    public int[] UInts2 { get; set; } = new int[8];
}
