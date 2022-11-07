using System.Collections.Generic;
using System.Threading.Tasks;
using prueba_back.Domain.Model;
using prueba_back.Domain.Repositories;
using prueba_back.Persistence;
using Microsoft.EntityFrameworkCore;

namespace prueba_back.Persistence{
    public class ItemRepository : BaseRepository, prueba_back.Domain.Repositories.IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context)
        {
        }  
        
        public async Task<IEnumerable<Item>> ListAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
        }

        public async Task<Item> FindByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }
        
        public void Update(Item item)
        {
            _context.Items.Update(item);
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
        }
    }
}