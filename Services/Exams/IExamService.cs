using DTOs.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exams
{
    public interface IExamService
    {
        int Add(CreateExamDto createExamDto);
    }
}
