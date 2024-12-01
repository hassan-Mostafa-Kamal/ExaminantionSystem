using AutoMapper;
using Core.Models;
using DTOs.Course;

namespace ExaminantionSystem.Mapping
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
                //.ForMember(des => des.Description, option =>option.MapFrom(sou=> sou.Description))
                //.ForMember(des => des.Title, option =>option.MapFrom(sou=> sou.Description))
                //.ForMember(des => des.Description, option =>option.MapFrom(sou=> sou.Description))
                //.ForMember(des => des.Description, option =>option.MapFrom(sou=> sou.Description));
        }
    }
}
