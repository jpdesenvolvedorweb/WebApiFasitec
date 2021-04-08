using WebAppFasitec.Context;
using WebAppFasitec.Entities;

namespace WebAppFasitec.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AppDbContext context) : base (context)
        {
        }
    }
}
