using AutoMapper;
using Core.Models;
using DTOs.Question;

namespace ExaminantionSystem.Mapping
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>();
               // .ForMember(des => des.);
        }
    }
}
