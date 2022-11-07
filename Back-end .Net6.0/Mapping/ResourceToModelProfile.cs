using System.Net.Mail;
using AutoMapper;
using prueba_back.Domain.Model;
using prueba_back.Resources;


namespace jobagapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            
            CreateMap<SaveItemResource, Item>();
        }
    }
}
