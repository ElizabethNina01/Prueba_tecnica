using System.Threading.Tasks;

namespace prueba_back.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompletedAsync();
    }
}
