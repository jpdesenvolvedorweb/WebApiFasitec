using WebAppFasitec.Context;
using WebAppFasitec.Entities;

namespace WebAppFasitec.Repository
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
