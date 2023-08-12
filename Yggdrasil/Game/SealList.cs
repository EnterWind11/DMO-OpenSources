using System.Runtime.Serialization.Formatters.Binary;
using Yggdrasil.Server.Game.Entities;

namespace Shared.Server.Game;

public class SealList
{
    private static BinaryFormatter Formatter = new();
    
    private readonly Seal[] _list;

    public SealList(int max)
    {
        _list = Enumerable.Repeat(new Seal(), max).ToArray();
    }

    public Seal this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    public int Count => _list.Length;

    public byte[] ToaArray()
    {
        using var stream = new MemoryStream();
        
        for (var i = 0; i < 120; ++i)
            stream.Write(_list[i].ToArray(), 0, 8);
        return stream.ToArray();
    }
}