using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DTOs.Question
{
    public class CreateQuestionDto
    {
        [Required]
        public QuestionLevel Level { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public decimal Score { get; set; }

       // public ICollection<Choice> Choices { get; set; } = new List<Choice>();

       // [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
       // public Instructor Instructor { get; set; }
        public int ExamId { get; set; } 
    }
}
