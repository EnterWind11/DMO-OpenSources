namespace Yggdrasil.Interfaces.Models;

[GenerateSerializer]
public class DbCharacterModel
{
    [Id(0)]
    public int Id { get; set; }
    
    [Id(1)]
    public int Pos { get; set; }
    
    [Id(2)]
    public DateTime CanDeleteAfter { get; set; } = new DateTime(2000, 1, 1, 1, 1, 1);
    
    [Id(3)]
    public long AccountId { get; set; }
    
    [Id(4)]
    public long CharModel { get; set; } = 80005;
    
    [Id(5)]
    public string CharacterName { get; set; }
    
    [Id(6)]
    public int CharLevel { get; set; } = 1;
    
    [Id(7)]
    public int Partner { get; set; }
    
    [Id(8)]
    public int Starter { get; set; } = 31001;
    
    [Id(9)]
    public int?[] Mercenaries { get; set; } = new int?[4];
    
    [Id(10)]
    public int MercenaryLimit { get; set; } = 6;
    
    [Id(11)]
    public long Money { get; set; } = 0;
    
    //public object Chipset { get; set; }
    
    [Id(12)]
    public int InventoryLimit { get; set; } = 30;
    // TODO:: Inv, storage, archive
    
    [Id(13)]
    public int StorageLimit { get; set; } = 21;
    
    [Id(14)]
    public int ArchiveLimit { get; set; } = 1;
    
    [Id(15)]
    public int Xai { get; set; } = 0;
    
    [Id(16)]
    public int XGauge { get; set; } = 0;

    [Id(17)]
    public int Map { get; set; } = 3;
    
    [Id(18)]
    public int X { get; set; } = 20009;
    
    [Id(19)]
    public int Y { get; set; } = 31585;
    
    [Id(20)]
    public int MaxHp { get; set; } = 90;
    
    [Id(21)]
    public int MaxDs { get; set; } = 80;
    
    [Id(22)]
    public int Ds { get; set; } = 80;
    
    [Id(23)]
    public int Hp { get; set; } = 90;
    
    [Id(24)]
    public int At { get; set; } = 10;
    
    [Id(25)]
    public int De { get; set; } = 2;
    
    [Id(26)]
    public int Ms { get; set; } = 1100;
    
    [Id(27)]
    public int Fatigue { get; set; } = 0;
}