﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Result:BaseModel
    {
        public int Grade { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Exam")]
        public int? ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
