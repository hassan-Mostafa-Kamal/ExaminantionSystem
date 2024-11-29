using Core.Enums;


namespace DTOs.Question
{
    public class QuestionDto
    {
     
        public QuestionLevel Level { get; set; }
      
        public string Body { get; set; }
        public decimal Score { get; set; }
        public DateOnly CreatedOn { get; set; } 


    }
}
