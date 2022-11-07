using System.Threading.Tasks;
using prueba_back.Domain.Repositories;


namespace prueba_back.Persistence
{
    public class UnitOfWork : prueba_back.Domain.Repositories.IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompletedAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
