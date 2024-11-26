using Core.Models;
using DTOs.Instructor;
using ExaminantionSystem.ManualMappingForInstructor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Contract;

namespace ExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IBaseRepository<Instructor> _instructorRepo;
        private readonly IBaseRepository<Course> _courseRepo;

        public InstructorController(IBaseRepository<Instructor> instructorRepo,IBaseRepository<Course> courseRepo)
        {
            _instructorRepo = instructorRepo;
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InstructorDto>> GetAll()
        {
            var instrctors = _instructorRepo.GetAll().ToInstructorDto();
            
            return Ok(instrctors);
        }

        //[HttpPost]
        //public ActionResult Create(InstructorCreateDto instructorDto)
        //{




        //}


        [HttpGet("{id}")]
        public  ActionResult<InstructorDto> GetById(int id)
        {
           // var instructor = await _instructorRepo.GetById(id);

            var instructor =  _instructorRepo.Get(e => e.Id == id).FirstOrDefault();
            instructor.ToInstructorDto();

            return Ok(instructor);
        }
    }
}
