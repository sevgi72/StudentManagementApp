using AutoMapper;
using StudentManagementApp.Dtos.Student;
using StudentManagementApp.Dtos.Group;
using StudentManagementApp.Models;

namespace StudentManagementApp.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Student mappings
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentReturnDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group != null ? src.Group.Name : null));

            // Group mappings
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();
            CreateMap<Group, GroupReturnDto>();
        }
    }
}
