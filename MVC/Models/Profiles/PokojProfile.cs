using AutoMapper;
using Models;

namespace MVC.Models.Profiles
{
    public class PokojProfile : Profile
    {
        public PokojProfile()
        {
            CreateMap<Pokoj, PokojViewModel>().ForMember(dest => dest.Rodzaj, opt => opt.MapFrom(src => src.RodzajPokoju));
            CreateMap<PokojViewModel, Pokoj>().ForMember(dest => dest.RodzajPokoju, opt => opt.MapFrom(src => src.Rodzaj));
        }
    }
}