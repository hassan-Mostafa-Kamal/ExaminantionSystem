using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Choice
{
    public class CreateChoiceDto
    {
        [Required]
        public string ChoiceTaxt { get; set; }

        [Required]
        public int? QuestionId { get; set; }
    }
}
