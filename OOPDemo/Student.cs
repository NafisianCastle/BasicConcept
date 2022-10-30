using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Student: Person
    {
        public string Department { get; set; }
        public List<Course> EnrolledCourses { get; set; }
        public List<Course> CompletedCourses { get; set; }

        protected override string Profession()
        {
            string profession = "Student";
            return profession;
        }
    }
}
