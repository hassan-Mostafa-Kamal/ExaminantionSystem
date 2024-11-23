using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Question
{
    public class EditQuestionDto
    {

        [Required]
        public QuestionLevel Level { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public decimal Score { get; set; }
        



    }
}
