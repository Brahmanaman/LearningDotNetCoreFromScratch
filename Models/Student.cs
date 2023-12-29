using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDotNetCoreFromScratch.Models
{
    public class Student
    {
        //PrimaryKey
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }

        //Navigation Property
        public ICollection<StudentCourse> StudentCourse { get; set; } = new List<StudentCourse>();
    }
}
