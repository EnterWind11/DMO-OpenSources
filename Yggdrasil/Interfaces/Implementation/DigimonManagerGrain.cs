using Orleans.Runtime;
using Yggdrasil.Interfaces;
using Yggdrasil.Interfaces.Models;

namespace Yggdrasil.Implementation;

public class DigimonState
{
    public int Index { get; set; } = 1;

    public List<DbDigimonModel> Digimon { get; set; } = new();
}

public class DigimonManagerGrain : Orleans.Grain, IDigimonManagerGrain
{
    private readonly IPersistentState<DigimonState> _state;
    public int AccountId => int.Parse(this.GetPrimaryKeyString().Split(":")[0]);

    public int CharacterId => int.Parse(this.GetPrimaryKeyString().Split(':')[1]);
    
    public DigimonManagerGrain([PersistentState("digimon")] IPersistentState<DigimonState> state)
    {
        _state = state;
    }

    public async Task<DbDigimonModel> AddAsync(DbDigimonModel digimonModel)
    {
        await _state.ReadStateAsync();

        digimonModel.Id = _state.State.Index;
        _state.State.Digimon.Add(digimonModel);

        await _state.WriteStateAsync();
        return digimonModel;
    }

    public async Task<DbDigimonModel?> FindAsync(int id)
    {
        await _state.ReadStateAsync();

        return _state.State.Digimon.First(a => a.Id == id);
    }

    public async Task<List<DbDigimonModel>> FindAllAsync()
    {
        await _state.ReadStateAsync();
        return _state.State.Digimon.ToList();
    }

    public Task MoveAsync(uint digiId, int x, int y)
    {
        var digimon = _state.State.Digimon.First(a => a.Id == digiId);
        
        return Task.CompletedTask;
    }

    public async Task EvolvedAsync(uint digiId, int newSpeciesId)
    {
        var digimon = _state.State.Digimon.First(a => a.Id == digiId);

        digimon.Model = newSpeciesId;
        await _state.WriteStateAsync();
    }
}