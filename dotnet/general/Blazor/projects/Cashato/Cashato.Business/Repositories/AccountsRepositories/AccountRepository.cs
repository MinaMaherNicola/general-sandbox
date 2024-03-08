using Cashato.Business.Dtos.Accounts;
using Cashato.Business.Repositories.Contracts;
using Cashato.DB.Context;
using Cashato.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace Cashato.Business.Repositories.AccountsRepositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        private readonly ILogger<AccountRepository> logger;
        public AccountRepository(CashatoContext context, ILogger<AccountRepository> logger) : base(context)
        {
            this.logger = logger;
        }

        public async Task AddAccount(AddAccountRequest request)
        {
            logger.LogInformation($"Open account request initiated by user-id: {request.UserId}.");
            EntityEntry<Account> result =
                await this.context.Accounts.AddAsync(new Account()
                {
                    Balance = request.Balance,
                    Type = request.Type,
                    UserId = request.UserId
                });
            await this.context.SaveChangesAsync();
            logger.LogInformation($"Open account request done. User-id: {request.UserId}, Account-id: {result.Entity.Id}.");
        }

        public async Task<int> GetNumberOfAccountsByUserId(string userId)
        {
            logger.LogInformation($"Fetching number of owned accounts to user {userId}.");

            return await this.context.Accounts.CountAsync(a => a.UserId.ToLower() == userId.ToLower());
        }
    }
}
