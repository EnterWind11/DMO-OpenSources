namespace Yggdrasil.Interfaces.Models;

[GenerateSerializer]
public class DbAccountModel
{
    [Id(0)]
    public uint AccountId { get; set; }
    
    [Id(1)]
    public long DiscordId { get; set; }
    
    [Id(2)]
    public string Username { get; set; }
    
    [Id(3)]
    public string Password { get; set; }
    
    [Id(4)]
    public string SecurityCode { get; set; } = "c4ca4238a0b923820dcc509a6f75849b";
    
    [Id(5)]
    public int Membership { get; set; } = 0;
    
    [Id(6)]
    public int Level { get; set; } = 0;
    
    [Id(7)]
    public string Email { get; set; }
    
    [Id(8)]
    public int UniqueId { get; set; }

    [Id(9)]
    public int[] Characters { get; set; } = new int[5];
    
    [Id(10)]
    public int LastChar { get; set; } = 0;
    
    [Id(11)]
    public int Crowns { get; set; } = 0;
}