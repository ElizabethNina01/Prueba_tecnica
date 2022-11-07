using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using prueba_back.Domain.Model;
using prueba_back.Domain.Repositories;
using prueba_back.Domain.Services.Communication;
using prueba_back.Domain.Services;

namespace prueba_back.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly Domain.Repositories.IUnitOfWork _unitOfWork;
        
        public ItemService(IItemRepository itemRepository, Domain.Repositories.IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Item>> ListAsync()
        {
            return await _itemRepository.ListAsync();
        }
        
        public async Task<ItemResponse> SaveAsync(Item item)
        {
            try
            {
                await _itemRepository.AddAsync(item);
                await _unitOfWork.CompletedAsync();

                return new ItemResponse(item);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error ocurred while saving the item: {e.Message}");
            }
        }

        public async Task<ItemResponse> UpdateAsync(int id, Item item)
        {
            var existingItem = await _itemRepository.FindByIdAsync(id);

            if (existingItem == null)
                return new ItemResponse("item not found.");
            //
            existingItem.Cant = item.Cant;
            existingItem.Cod = item.Cod;
            existingItem.DescArt = item.DescArt;
            existingItem.NameArt = item.NameArt;
            
            try
            {
                _itemRepository.Update(existingItem);
                await _unitOfWork.CompletedAsync();

                return new ItemResponse(existingItem);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error ocurred while saving the item: {e.Message}");
            }
        }

        public async Task<ItemResponse> DeleteAsync(int id)
        {
            var existingItem = await _itemRepository.FindByIdAsync(id);
            
            if(existingItem == null)
                return new ItemResponse("item not found.");

            try
            {
                _itemRepository.Delete(existingItem);
                await _unitOfWork.CompletedAsync();

                return new ItemResponse(existingItem);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error ocurred while deleting the item: {e.Message}");

            }
        }
    }
}