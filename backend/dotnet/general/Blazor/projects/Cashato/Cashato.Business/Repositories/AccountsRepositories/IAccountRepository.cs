using Cashato.Business.Dtos.Accounts;

namespace Cashato.Business.Repositories.AccountsRepositories
{
    public interface IAccountRepository
    {
        Task AddAccount(AddAccountRequest request);
        Task<int> GetNumberOfAccountsByUserId(string userId);
    }
}
