using Cashato.DB.Context;

namespace Cashato.Business.Repositories.Contracts
{
    public abstract class BaseRepository
    {
        internal readonly CashatoContext context;

        protected BaseRepository(CashatoContext context)
        {
            this.context = context;
        }
    }
}
