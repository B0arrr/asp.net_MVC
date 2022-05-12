using AutoMapper;
using Models;

namespace MVC.Models.Profiles
{
    public class HostelProfile : Profile
    {
        public HostelProfile()
        {
            CreateMap<Hostel, HostelItemViewModel>();
            CreateMap<Hostel, HostelViewModel>();
            CreateMap<HostelItemViewModel, Hostel>();
            CreateMap<HostelViewModel, Hostel>();
        }
    }
}
