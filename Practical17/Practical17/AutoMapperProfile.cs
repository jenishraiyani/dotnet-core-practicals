using AutoMapper;
using Practical17.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practical17
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>();
        }
    }
}
