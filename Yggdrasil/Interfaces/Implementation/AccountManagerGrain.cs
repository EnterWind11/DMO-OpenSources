using Orleans.Runtime;
using Yggdrasil.Interfaces;
using Yggdrasil.Interfaces.Models;

namespace Yggdrasil.Implementation;

[GenerateSerializer]
public class AccountState
{
    [Id(0)]
    public uint Index { get; set; } = 1;

    [Id(1)] 
    public List<DbAccountModel> AccountModels { get; set; } = new List<DbAccountModel>();
}

public class AccountManagerGrain : Orleans.Grain, IAccountManagerGrain
{
    private readonly IPersistentState<AccountState> _storage;

    public AccountManagerGrain([PersistentState("accounts")]IPersistentState<AccountState> storage)
    {
        _storage = storage;
    }

    public async Task<DbAccountModel?> FindAsync(string username, string password)
    {
        await _storage.ReadStateAsync();
        var account =
            _storage.State.AccountModels.FirstOrDefault(a => a.Username == username && a.Password == password);

        return account;
    }

    public async Task<DbAccountModel?> FindAsync(uint accountId, int uniqueId)
    {
        await _storage.ReadStateAsync();
        var account =
            _storage.State.AccountModels.FirstOrDefault(a => a.AccountId == accountId && a.UniqueId == uniqueId);

        return account;
    }

    public async Task<DbAccountModel?> CreateAsync(string username, string password)
    {
        await _storage.ReadStateAsync();

        var account = new DbAccountModel
        {
            AccountId = _storage.State.Index,
            Username = username,
            Password = password,
            UniqueId = (int)_storage.State.Index * 1000
        };

        _storage.State.Index++;
        _storage.State.AccountModels.Add(account);
        await _storage.WriteStateAsync();
        return account;
    }

    public async Task SetLastCharAsync(uint clientAccountId, int slot)
    {
        await _storage.ReadStateAsync();

        _storage.State.AccountModels.First(a => a.AccountId == clientAccountId).LastChar = slot;
        await _storage.WriteStateAsync();
    }
}