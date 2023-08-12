using System.Runtime.Serialization.Formatters.Binary;
using Yggdrasil.Server.Game.Entities;

namespace Shared.Server.Game;

[Serializable]
public sealed class SlottedItemList
{
    private Item[] _entities;

    public SlottedItemList(int max)
    {
        _entities = Enumerable.Repeat(new Item(0), max).ToArray();
    }

    public Item this[int index]
    {
        get => _entities[index];
        set => _entities[index] = value;
    }

    public int Count => _entities.Count(i => i.ItemId > 0);

    public bool IsFull => Count >= _entities.Length;
    
    public int FindItemSlot(int itemId)
    {
        for (var slot = 1; slot < _entities.Length; slot++)
        {
            if (_entities[slot].ItemId == itemId) return slot;
        }

        return -1;
    }

    public Item? FindItem(short itemId)
    {
        var slot = FindItemSlot(itemId);
        return slot == -1 ? null : _entities[slot];
    }

    public int Add(Item i)
    {
        var openSlot = NextSlot();
        if (openSlot == -1) return -1;

        _entities[openSlot] = i;
        return openSlot;
    }

    public int Add(Item i, int slot)
    {
        if (slot == -1) return -1;

        _entities[slot] = i;
        return slot;
    }

    public bool Remove(Item i)
    {
        var slot = FindItemSlot(i.ItemId);
        if (slot == -1) return false;

        _entities[slot] = new Item();
        return true;
    }

    public bool Remove(int slot)
    {
        if (slot == -1) return false;

        _entities[slot] = new Item();
        return true;
    }

    public bool Contains(Item item) => Contains(item.ItemId);
    public bool Contains(int itemId) => FindItemSlot(itemId) != -1;

    public int EquipSlot(short slotId)
    {
        return slotId - slotId switch
        {
            >= 1000 and <= 1013 => 1000,
            >= 2000 and <= 2400 => 2000,
            >= 4000 and <= 4008 => 4000,
            5000 => 4986,
            >= 9000 and <= 9014 => 9000,
            _ => slotId
        };
    }

    private int NextSlot() => _entities
        .Select((item, id) => new { ItemId = item.ItemId, Slot = id })
        .FirstOrDefault(a => a.ItemId == 0, new { ItemId = -1, Slot = -1 })
        .Slot;

    public byte[] ToArray()
    {
        using var memoryStream = new MemoryStream();
        foreach (var t in _entities)
            memoryStream.Write(t.ToArray(), 0, 68);

        return memoryStream.ToArray();
    }
}