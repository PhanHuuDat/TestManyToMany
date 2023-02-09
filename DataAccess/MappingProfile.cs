using AutoMapper;
using TestManyToMany.DTOs;
using TestManyToMany.Models;

namespace TestManyToMany.DataAccess
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book,BookDTO>().ForMember(dto => dto.Tags, opt => opt.MapFrom(dao => dao.Tags.ToList())).ReverseMap();
            CreateMap<Tag,TagDTO>().ReverseMap();
        }
    }
}
