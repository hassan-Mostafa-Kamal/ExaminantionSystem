using AutoMapper;
using Core.Models;
using DTOs.Exam;
using Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exams
{
    public class ExamService : IExamService
    {

        private readonly IBaseRepository<Exam> _examRepo;
        private readonly IBaseRepository<ExamQuestion> _examQuestionRepo;
        private readonly IMapper _mapper;

        public ExamService(IBaseRepository<Exam> examRepo, IMapper mapper, IBaseRepository<ExamQuestion> examQuestionRepo)
        {
            _examRepo = examRepo;
            _mapper = mapper;
            _examQuestionRepo = examQuestionRepo;
        }

        public int Add(CreateExamDto createExamDto)
        {
            var exam = new Exam()
            {
                InstructorId = createExamDto.InstructorId,
                TotalGrade = createExamDto.TotalGrade,
                PassMark = createExamDto.PassMark,
                MaxDuration = createExamDto.MaxDuration,
                Type = createExamDto.Type,
                //ExamQuestions = createExamDto.QuestionsIds.Select(x => new ExamQuestion
                //{
                //    QuestionId = x
                //}).ToList()


            };

             _examRepo.Add(exam);
            _examRepo.SaveChanges();
            foreach (var questionId in createExamDto.QuestionsIds)
            {
                 _examQuestionRepo.Add(new ExamQuestion
                {
                    QuestionId = questionId,
                    ExamId = exam.Id,
                });
            }
            _examQuestionRepo.SaveChanges();

            return exam.Id;
        }

        
    }
}
