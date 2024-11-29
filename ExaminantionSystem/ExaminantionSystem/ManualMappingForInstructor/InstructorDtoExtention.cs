using Core.Models;
using DTOs.Instructor;
using System.Net;

namespace ExaminantionSystem.ManualMappingForInstructor
{
    public static class InstructorDtoExtention
    {
        public static InstructorDto ToInstructorDto(this Instructor instructor)
        {
            return new InstructorDto
            {
                Address = instructor.Address,
                Age = instructor.Age,
                Name = instructor.Name,
                BarthDate = instructor.BarthDate,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                Salary = instructor.Salary
            };
        }

        public static IEnumerable<InstructorDto> ToInstructorDto(this IQueryable<Instructor> instructors)
        {
            return instructors.Select(i =>new  InstructorDto
            {
                Address = i.Address,
                Age = i.Age,
                Name = i.Name,
                BarthDate = i.BarthDate,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                Salary = i.Salary
            }).ToList();

           // return instructors.Select(i => i.ToInstructorDto()).ToList();
        }
    }
}
