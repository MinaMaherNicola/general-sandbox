using Cashato.DB.Enums;

namespace Cashato.Business.Dtos.Accounts
{
    public class AddAccountRequest
    {
        public string UserId { get; set; } = null!;
        public decimal Balance { get; set; }
        public AccountTypeEnum Type { get; set; }
    }
    //(string UserId, decimal Balance, AccountTypeEnum Type);
}
