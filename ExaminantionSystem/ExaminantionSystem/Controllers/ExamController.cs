using AutoMapper;
using Core.Enums;
using Core.Models;
using DTOs.Exam;
using ExaminantionSystem.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;

namespace ExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly IBaseRepository<Exam> _examRepo;
        private readonly IMapper _mapper;

        public ExamController(IBaseRepository<Exam> examRepo, IMapper mapper)
        {
            _examRepo = examRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateExamDto>> Create(CreateExamDto createExamDto)
        {


            var Exam = new Exam()
            {
                InstructorId = createExamDto.InstructorId,
                TotalGrade = createExamDto.TotalGrade,
                PassMark = createExamDto.PassMark,
                MaxDuration = createExamDto.MaxDuration,
                Type = createExamDto.Type

            };

            await _examRepo.Add(Exam);
            return Ok(createExamDto);

            //var examTypes = Enum.GetValues(typeof(ExamType))
            //            .Cast<ExamType>()
            //            .Select(e => new { Id = (int)e, Name = e.ToString() })
            //            .ToList();

            //return Ok(new
            //{
            //    Message = "Exam created successfully",
            //    Exam = createExamDto,
            //    ExamTypes = examTypes
            //});



        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDto>>> GetAll()
        {
            var Exames = await _examRepo.GetAll().ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ExamDto>>(Exames));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int? id, EditExamDto editExamDto)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var ExamFromDb = await _examRepo.Get(c => c.Id == id);
            if (ExamFromDb == null)
            {
                return NotFound();
            }

            ExamFromDb.MaxDuration = editExamDto.MaxDuration;
            ExamFromDb.PassMark = editExamDto.PassMark;
            ExamFromDb.TotalGrade = editExamDto.TotalGrade;
            ExamFromDb.Type = editExamDto.Type;
            ExamFromDb.UpdetedOn = DateOnly.FromDateTime(DateTime.Now);

            await _examRepo.Update(ExamFromDb);
            return Ok();


        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var examFromDb = await _examRepo.Get(c => c.Id == id);
            if (examFromDb == null)
            {
                return NotFound();
            }

            await _examRepo.SoftDelete(examFromDb);
            return Ok("Exam Deleted Successfully");

        }

    }
}
