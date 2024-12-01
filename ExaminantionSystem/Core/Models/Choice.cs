using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Choice:BaseModel
    {
        public string ChoiceTaxt { get; set; }

        [ForeignKey("Question")]
        public int? QuestionId { get; set; }
        public Question Question { get; set; }

    }
}
