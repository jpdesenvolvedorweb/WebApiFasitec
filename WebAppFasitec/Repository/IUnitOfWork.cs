namespace WebAppFasitec.Repository
{
    public interface IUnitOfWork
    {
        IContratoRepository ContratoRepository { get; }

        IFaturaRepository FaturaRepository { get; }
        
        IParcelaRepository ParcelaRepository { get; }

        IPessoaRepository PessoaRepository { get; }

        void Commit();
    }
}
