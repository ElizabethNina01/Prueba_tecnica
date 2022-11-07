using System.Collections.Generic;
using System.Threading.Tasks;
using prueba_back.Domain.Model;

namespace prueba_back.Domain.Repositories
{
    public interface IItemRepository
    {
        
        Task<IEnumerable<Item>> ListAsync();
        Task AddAsync(Item item);

        Task<Item> FindByIdAsync(int id);

        void Update(Item item);

        void Delete(Item item);
    }
}