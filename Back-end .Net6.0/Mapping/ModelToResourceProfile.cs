using AutoMapper;
using prueba_back.Domain.Model;
using prueba_back.Resources;


namespace prueba_back.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {

            CreateMap<Item, ItemResource>();

        
        }
    }
}