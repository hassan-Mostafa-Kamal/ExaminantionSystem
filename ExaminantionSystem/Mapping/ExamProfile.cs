using AutoMapper;
using Core.Models;
using DTOs.Exam;

namespace ExaminantionSystem.Mapping
{
    public class ExamProfile:Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam ,ExamDto>();
        }
    }
}
