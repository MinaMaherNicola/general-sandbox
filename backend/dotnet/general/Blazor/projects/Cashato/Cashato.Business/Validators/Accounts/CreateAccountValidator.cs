using Cashato.Business.Dtos.Accounts;
using Cashato.Business.Repositories.AccountsRepositories;
using FluentValidation;

namespace Cashato.Business.Validators.Accounts
{
    public class CreateAccountValidator : AbstractValidator<AddAccountRequest>
    {
        private readonly IAccountRepository accountRepository;
        public CreateAccountValidator(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;

            RuleFor(r => r.Balance).GreaterThanOrEqualTo(500).WithMessage("Minimum limit to open an account is 500");
            RuleFor(r => r.UserId).MustAsync(GetNumberOfAccountsOwnedByUser).WithMessage("You cannot open more than 2 accounts");
        }

        private async Task<bool> GetNumberOfAccountsOwnedByUser(string userId, CancellationToken cancellationToken)
        {
            return await accountRepository.GetNumberOfAccountsByUserId(userId) <= 2;
        }
    }
}
