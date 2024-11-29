using AutoMapper;
using Core.Models;
using DTOs.Choice;

namespace ExaminantionSystem.Mapping
{
    public class ChoiceProfile:Profile
    {

        public ChoiceProfile()
        {
            CreateMap<Choice, ChoiceDto>();
        }
    }
}
