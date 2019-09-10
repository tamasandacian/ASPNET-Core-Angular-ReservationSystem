using AutoMapper;
using webapi.Models;
using webapi.Models.ViewModels;

namespace webapi.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerVM, Customer>();
        }
    }
}