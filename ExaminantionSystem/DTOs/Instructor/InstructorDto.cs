﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Instructor
{
    public class InstructorDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public DateOnly BarthDate { get; set; }
        public decimal Salary { get; set; }

    }
}
