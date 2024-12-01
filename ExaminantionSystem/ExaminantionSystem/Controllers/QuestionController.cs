using AutoMapper;
using Core.Models;
using DTOs.Question;
using ExaminantionSystem.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;

namespace ExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IBaseRepository<Question> _questionRepo;
        private readonly IBaseRepository<ExamQuestion> _examQustionRepo;
        private readonly IMapper _mapper;

        public QuestionController(IBaseRepository<Question> questionRepo,IBaseRepository<ExamQuestion> examQustionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _examQustionRepo = examQustionRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateQuestionDto>> Create(CreateQuestionDto createQuestionDto)
        {


            var Question = new Question()
            {
                Score = createQuestionDto.Score,
                Level = createQuestionDto.Level,
                Body = createQuestionDto.Body,
              


            };

           // await _questionRepo.Add(Question);

            var examQuestion = new ExamQuestion
            {
                ExamId = createQuestionDto.ExamId,
                Question = Question
            };


            await _examQustionRepo.Add(examQuestion);

            return Ok(createQuestionDto);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAll()
        {
            var Exames = await _questionRepo.GetAll().ToListAsync();

            return Ok(_mapper.Map<IEnumerable<QuestionDto>>(Exames));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int? id, EditQuestionDto editQuestionDto)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var ExamFromDb = await _questionRepo.Get(c => c.Id == id);
            if (ExamFromDb == null)
            {
                return NotFound();
            }

            ExamFromDb.Level = editQuestionDto.Level;
            ExamFromDb.Body = editQuestionDto.Body;
            ExamFromDb.Score = editQuestionDto.Score;
            ExamFromDb.UpdetedOn = DateOnly.FromDateTime(DateTime.Now);

            await _questionRepo.Update(ExamFromDb);
            return Ok();


        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var examFromDb = await _questionRepo.Get(c => c.Id == id);
            if (examFromDb == null)
            {
                return NotFound();
            }

            await _questionRepo.SoftDelete(examFromDb);
            return Ok("Question Deleted Successfully");

        }

    }
}
