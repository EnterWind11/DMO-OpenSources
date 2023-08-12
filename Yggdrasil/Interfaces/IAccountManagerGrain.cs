using Orleans;
using Orleans.Concurrency;
using Yggdrasil.Interfaces.Models;

namespace Yggdrasil.Interfaces;

public interface IAccountManagerGrain : IGrainWithIntegerKey
{
    [AlwaysInterleave]
    Task<DbAccountModel?> FindAsync(string username, string password);
    
    [AlwaysInterleave]
    Task<DbAccountModel?> FindAsync(uint accountId, int uniqueId);

    Task<DbAccountModel?> CreateAsync(string username, string password);
    
    [AlwaysInterleave]
    Task SetLastCharAsync(uint clientAccountId, int slot);
}