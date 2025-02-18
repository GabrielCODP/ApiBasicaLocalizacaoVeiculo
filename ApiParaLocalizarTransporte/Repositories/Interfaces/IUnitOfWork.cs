namespace ApiParaLocalizarTransporte.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        //Instancias dos repositorios
        IParadaRepository ParadaRepository { get; }
        ILinhaRepository LinhaRepository { get; }
        Task CommitAsync();
    }
}
