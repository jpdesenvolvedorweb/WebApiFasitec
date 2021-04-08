using WebAppFasitec.Context;
using WebAppFasitec.Entities;

namespace WebAppFasitec.Repository
{
    public class FaturaRepository : Repository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
