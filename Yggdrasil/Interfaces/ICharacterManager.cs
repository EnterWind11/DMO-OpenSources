using Orleans;
using Orleans.Concurrency;
using Yggdrasil.Interfaces.Models;

namespace Yggdrasil.Interfaces;

public interface ICharacterManagerGrain : IGrainWithIntegerKey
{
    [AlwaysInterleave]
    Task<List<DbCharacterModel>> FindAllAsync();
    [AlwaysInterleave]
    Task<DbCharacterModel?> FindAsync(int characterId);
    Task<DbCharacterModel> AddAsync(DbCharacterModel characterModel);
    Task<bool> DeleteAsync(DbCharacterModel characterModel);

    Task UpdatePartner(int characterId, int digimonId);
    
    [AlwaysInterleave]
    Task<DbCharacterModel> FindBySlotAsync(int slot);

    [AlwaysInterleave]
    Task MoveAsync(int characterId, int x, int y, int? mapId = null);
}