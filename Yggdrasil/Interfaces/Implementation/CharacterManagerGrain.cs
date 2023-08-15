using Orleans.Runtime;
using Yggdrasil.Interfaces;
using Yggdrasil.Interfaces.Models;

namespace Yggdrasil.Implementation;

[GenerateSerializer]
public class CharacterState
{
    [Id(0)]
    public int Index { get; set; } = 1;

    [Id(1)]
    public List<DbCharacterModel> CharacterModels { get; set; } = new List<DbCharacterModel>();
}

public class CharacterManagerGrain : Orleans.Grain, ICharacterManagerGrain
{
    private readonly IPersistentState<CharacterState> _storage;

    public CharacterManagerGrain([PersistentState("characters")]IPersistentState<CharacterState> storage)
    {
        _storage = storage;
    }
    
    public async Task<List<DbCharacterModel>> FindAllAsync()
    {
        await _storage.ReadStateAsync();
        return _storage.State.CharacterModels.ToList();
    }

    public async Task<DbCharacterModel?> FindAsync(int characterId)
    {
        await _storage.ReadStateAsync();

        var character = _storage.State.CharacterModels.FirstOrDefault(a => a.Id == characterId);
        return character;
    }

    public async Task<DbCharacterModel> AddAsync(DbCharacterModel characterModel)
    {
        await _storage.ReadStateAsync();
        
        characterModel.Id = _storage.State.Index;
        _storage.State.Index++;
        _storage.State.CharacterModels.Add(characterModel);

        await _storage.WriteStateAsync();
        return characterModel;
    }

    public async Task<bool> DeleteAsync(DbCharacterModel characterModel)
    {
        await _storage.ReadStateAsync();

        var index = _storage.State.CharacterModels.FindIndex(a => a.Id == characterModel.Id);
        _storage.State.CharacterModels.RemoveAt(index);
        await _storage.WriteStateAsync();

        return true;
    }

    public async Task UpdatePartner(int characterId, int digimonId)
    {
        var character = _storage.State.CharacterModels.First(a => a.Id == characterId);

        character.Partner = digimonId;
        await _storage.WriteStateAsync();
    }

    public Task<DbCharacterModel> FindBySlotAsync(int slot)
    {
        return Task.FromResult(_storage.State.CharacterModels[slot]);
    }

    public async Task MoveAsync(int characterId, int x, int y, int? mapId = null)
    {
        var character = _storage.State.CharacterModels.First(a => a.Id == characterId);

        character.Map = mapId ?? character.Map;
        character.X = x;
        character.Y = y;

        await _storage.WriteStateAsync();
    }
}