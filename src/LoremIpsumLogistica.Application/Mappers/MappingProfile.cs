using AutoMapper;
using LoremIpsumLogistica.Application.ViewModels;

namespace LoremIpsumLogistica.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {          
            CreateMap<Core.Entities.Client, CreateClientViewModel>().ReverseMap();
            CreateMap<Core.Entities.Client, ClientViewModel>().ReverseMap();

            CreateMap<Core.Entities.Address, AddressViewModel>().ReverseMap();
        }
    }
}
