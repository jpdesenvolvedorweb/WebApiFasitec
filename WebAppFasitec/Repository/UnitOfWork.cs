using WebAppFasitec.Context;

namespace WebAppFasitec.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContratoRepository _contratoRepo;
        private FaturaRepository _faturaRepo;
        private ParcelaRepository _parcelaRepo;
        private PessoaRepository _pessoaRepo;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IContratoRepository ContratoRepository
        {
            get
            {
                return _contratoRepo = _contratoRepo ?? new ContratoRepository(_context);
            }
        }

        public IFaturaRepository FaturaRepository
        {
            get
            {
                return _faturaRepo = _faturaRepo ?? new FaturaRepository(_context);
            }
        }

        public IParcelaRepository ParcelaRepository
        {
            get
            {
                return _parcelaRepo = _parcelaRepo ?? new ParcelaRepository(_context);
            }
        }

        public IPessoaRepository PessoaRepository
        {
            get
            {
                return _pessoaRepo = _pessoaRepo ?? new PessoaRepository(_context);
            }
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
