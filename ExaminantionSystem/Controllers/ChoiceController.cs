using AutoMapper;
using Core.Models;
using DTOs.Choice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;

namespace ExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class choiceController : ControllerBase
    {

        private readonly IBaseRepository<Choice> _choiceRepo;
        private readonly IBaseRepository<Question> _questioRepo;
        private readonly IMapper _mapper;

        public choiceController(IBaseRepository<Choice> choiceRepo,IBaseRepository<Question> questioRepo,  IMapper mapper)
        {
            _choiceRepo = choiceRepo;
            _questioRepo = questioRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateChoiceDto>> Create(CreateChoiceDto createChoiceDto)
        {
            var questionExists = await _questioRepo.GetById(createChoiceDto.QuestionId ) != null;


            if (!questionExists)
            {
                return BadRequest(new { Message = "The specified QuestionId does not exist." });
            }
            var Choice = new Choice()
            {
                ChoiceTaxt = createChoiceDto.ChoiceTaxt,
                QuestionId = createChoiceDto.QuestionId,

            };

         


            await _choiceRepo.Add(Choice);

            return Ok(createChoiceDto);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChoiceDto>>> GetAll()
        {
            var choices = await _choiceRepo.GetAll().ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ChoiceDto>>(choices));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int? id, EditChoiceDto editChoiceDto)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var ExamFromDb = await _choiceRepo.Get(c => c.Id == id);
            if (ExamFromDb == null)
            {
                return NotFound();
            }

            var questionExists = await _questioRepo.GetById(editChoiceDto.QuestionId) != null;


            if (!questionExists)
            {
                return BadRequest(new { Message = "The specified QuestionId does not exist." });
            }

            ExamFromDb.ChoiceTaxt= editChoiceDto.ChoiceTaxt;
            ExamFromDb.QuestionId =editChoiceDto.QuestionId;
            ExamFromDb.UpdetedOn = DateOnly.FromDateTime(DateTime.Now);

            await _choiceRepo.Update(ExamFromDb);
            return Ok();


        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var choiceFromDb = await _choiceRepo.Get(c => c.Id == id);
            if (choiceFromDb == null)
            {
                return NotFound();
            }

            await _choiceRepo.SoftDelete(choiceFromDb);
            return Ok("Choice Deleted Successfully");

        }
    }
}
