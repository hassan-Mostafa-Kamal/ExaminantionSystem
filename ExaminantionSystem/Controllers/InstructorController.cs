using Core.Models;
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


    }
}
