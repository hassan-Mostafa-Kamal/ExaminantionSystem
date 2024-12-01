using AutoMapper;
using Core.Models;
using DTOs.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;

namespace ExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IBaseRepository<Course> _courseRepo;
        private readonly IMapper _mapper;

        public CourseController(IBaseRepository<Course> courseRepo,IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCourseDto>> Create(CreateCourseDto createCourseDto)
        {
            
           
          var course = new Course()
          {
              Description = createCourseDto.Description,
              Title = createCourseDto.Title,
              Hours = createCourseDto.Hours,
              
          };

          await  _courseRepo.Add(course);
            return Ok(createCourseDto);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var courses = await _courseRepo.GetAll().ToListAsync();

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int? id ,EditCourseDto editCourseDto)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var courseFromDb = await _courseRepo.Get(c=>c.Id == id);
            if (courseFromDb == null) { 
                return NotFound();
            }

            courseFromDb.Hours = editCourseDto.Hours;
            courseFromDb.Description = editCourseDto.Description;
            courseFromDb.Title = editCourseDto.Title;
            courseFromDb.UpdetedOn = DateOnly.FromDateTime(DateTime.Now);

            await _courseRepo.Update(courseFromDb);
            return Ok();


        }

        [HttpDelete]
        public async Task<ActionResult>  Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var courseFromDb = await _courseRepo.Get(c => c.Id == id);
            if (courseFromDb == null)
            {
                return NotFound();
            }

            await _courseRepo.SoftDelete(courseFromDb);
            return Ok("Course Deleted Successfully");

        }

    }
}
