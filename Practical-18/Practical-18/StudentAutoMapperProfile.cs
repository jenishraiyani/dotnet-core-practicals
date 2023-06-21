using AutoMapper;
using Practical_18.Models;

namespace Practical_18
{
    public class StudentAutoMapperProfile : Profile
    {
        public StudentAutoMapperProfile() {

            CreateMap<StudentDto, Students>();
        }

    }
}
