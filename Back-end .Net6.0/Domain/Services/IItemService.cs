using System.Collections.Generic;
using System.Threading.Tasks;
using prueba_back.Domain.Services.Communication;

namespace prueba_back.Domain.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Model.Item>> ListAsync();
        Task<ItemResponse> SaveAsync(Model.Item item);

        Task<ItemResponse> UpdateAsync(int id, Model.Item item);

        Task<ItemResponse> DeleteAsync(int id);
        
    }
}