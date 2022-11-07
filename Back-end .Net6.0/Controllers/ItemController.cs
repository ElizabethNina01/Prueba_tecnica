using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using prueba_back.Domain.Model;
using prueba_back.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using prueba_back.Extensions;
using prueba_back.Resources;

namespace prueba_back.Controllers
{
    [Route("/api/v1/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemResource>> GetAllAsync()
        {
            var items = await _itemService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Item>, IEnumerable<ItemResource>>(items);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveItemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var item = _mapper.Map<SaveItemResource, Item>(resource);
            var result = await _itemService.SaveAsync(item);

            if (!result.Success)
                return BadRequest(result.Message);
            var itemResource = _mapper.Map<Item, ItemResource>(result.Resource);
            return Ok(itemResource);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveItemResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var item = _mapper.Map<SaveItemResource, Item>(resource);
            var result = await _itemService.UpdateAsync(id, item);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Item, ItemResource>(result.Resource);
            return Ok(itemResource);
        } 
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _itemService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Item, ItemResource>(result.Resource);
            return Ok(itemResource);
        
        }

        

    }
}