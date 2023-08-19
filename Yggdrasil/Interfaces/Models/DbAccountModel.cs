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
    public string SecurityCode { get; set; } = "e10adc3949ba59abbe56e057f20f883e";  //2-Pass em md5 senha padrão 123456
    
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

    [Id(12)]
    public int OpenTamerSlot { get; set; } = 5;

    [Id(13)]
    public int MaxTamerSlot { get; set; } = 5;

    [Id(14)]
    public int SubType { get; set; } = 3;  // 1=Skip 2=Pass 3=NewPass  
}