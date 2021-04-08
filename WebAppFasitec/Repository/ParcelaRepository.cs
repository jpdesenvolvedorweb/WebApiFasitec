using WebAppFasitec.Context;
using WebAppFasitec.Entities;

namespace WebAppFasitec.Repository
{
    public class ParcelaRepository : Repository<Parcela>, IParcelaRepository 
    {
        public ParcelaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
