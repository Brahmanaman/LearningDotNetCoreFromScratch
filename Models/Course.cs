﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDotNetCoreFromScratch.Models
{
    public class Course
    {
        //PrimaryKey
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        //Navigation Property
        public ICollection<StudentCourse> Enrollment { get; set; }
    }
}
