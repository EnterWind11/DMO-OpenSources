using Shared.Server.Game;

namespace Yggdrasil.Server.Game.Entities;

public class Character
{
    public uint AccountId { get; set; }
    public uint CharacterId { get; set; }
    public int CharacterPos { get; set; }

    public int Starter { get; set; }
    
    public uint IntHandle { get; set; }

    public SlottedItemList Equipment { get; set; } = new SlottedItemList(15);

    public int Level { get; set; } = 1;

    public CharacterModel Model { get; set; } = CharacterModel.NULL;

    public string Name { get; set; } = string.Empty;
    public string GuildName { get; set; } = string.Empty;
    
    public int LastChar { get; set; }
    public int Money { get; set; }
    public int Crowns { get; set; }
    public int CurrentTitle { get; set; }
    public int CurrentSealLeader { get; set; }
    public int MaxHp { get; set; }
    public int MaxDs { get; set; }
    public int Hp { get; set; }
    public int Ds { get; set; }
    public int At { get; set; }
    public int De { get; set; }
    public int Exp { get; set; }
    public int Ms { get; set; }
    public int Fatigue { get; set; }


    public Position Location { get; set; }
    
    public int InventorySize { get; set; } = 21;
    public int StorageSize { get; set; } = 21;
    public int ArchiveSize { get; set; } = 1;
    public int MercenaryLimit { get; set; } = 3;

    public SlottedItemList Inventory { get; set; } = new(150);
    public SlottedItemList Storage { get; set; } = new(315);
    public SlottedItemList AccountStorage { get; set; } = new(14);
    public SlottedItemList Chipsets { get; set; } = new(12);

    public SealList Seals { get; set; } = new(20);

    public Digimon[] DigimonList { get; set; } = new Digimon[5];
    public uint[] ArchivedDigimon { get; set; } = new uint[150];


    public short DigimonHandle { get; set; }
    
    public Digimon Partner
    {
        get => DigimonList[0];
        set => DigimonList[0] = value;
    }
    
    public uint ProperModel => (uint) (10240160 + (int) (this.Model - 80001) * 128 << 8);

    public ushort TamerHandle => BitConverter.ToUInt16(new byte[2]
    {
        (byte) (this.IntHandle & (uint) byte.MaxValue),
        (byte) 128
    }, 0);

    public short BTamerHandle => BitConverter.ToInt16(new byte[2]
    {
        (byte) (this.IntHandle & (uint) byte.MaxValue),
        (byte) 0
    }, 0);
}