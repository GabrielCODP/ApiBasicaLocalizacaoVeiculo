using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.Repositories.Interfaces;

namespace ApiParaLocalizarTransporte.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IParadaRepository? _paradaRepo;
        private ILinhaRepository? _linhaRepo;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IParadaRepository ParadaRepository
        {
            //Verificar se tenho 
            //uma instancia se não tiver vou criar uma
            get
            {
                return _paradaRepo = _paradaRepo ?? new ParadaRepository(_context);
            }
        }

        public ILinhaRepository LinhaRepository
        {
            //Verificar se tenho 
            //uma instancia se não tiver vou criar uma
            get
            {
                return _linhaRepo = _linhaRepo ?? new LinhaRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Dipose()
        {
            await _context.DisposeAsync();
        }
    }
}
