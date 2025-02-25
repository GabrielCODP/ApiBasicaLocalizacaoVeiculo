using ApiParaLocalizarTransporte.Context;
using ApiParaLocalizarTransporte.Repositories.Interfaces;

namespace ApiParaLocalizarTransporte.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IParadaRepository? _paradaRepo;
        private ILinhaRepository? _linhaRepo;
        private IVeiculoRepository? _veiculoRepo;
        private IPosicaoVeiculoRepository _posicaoVeiculoRepo;

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

        public IVeiculoRepository VeiculoRepository
        {
            get
            {
                return _veiculoRepo = _veiculoRepo ?? new VeiculoRepository(_context);
            }
        }

        public IPosicaoVeiculoRepository PosicaoVeiculoRepository
        {
            get
            {
                return _posicaoVeiculoRepo = 
                    _posicaoVeiculoRepo ?? new PosicaoVeiculoRepository(_context);
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
