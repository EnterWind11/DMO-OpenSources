using Orleans.Concurrency;
using Yggdrasil.Interfaces.Models;

namespace Yggdrasil.Interfaces;

public interface IDigimonManagerGrain : IGrainWithStringKey
{
    Task<DbDigimonModel> AddAsync(DbDigimonModel digimonModel);

    Task<DbDigimonModel?> FindAsync(int id);

    Task<List<DbDigimonModel>> FindAllAsync();
    
    [AlwaysInterleave]
    Task MoveAsync(uint digiId, int x, int y);

    Task EvolvedAsync(uint digiId, int newSpeciesId);
}