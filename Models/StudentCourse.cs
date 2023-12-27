using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDotNetCoreFromScratch.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        
       //Student Navigation Property
       //Student ForeignKey
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //Course Navigation Property
        //Course ForeignKey
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
