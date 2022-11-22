using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class Teacher : Person
    {
        public string Designation { get; set; }
        public double Salary { get; set; }
        public int Status { get; set; }

      
        /// <summary>
        ///  If you use sealed keyword, the AssistantTeacher can't override Profession() of Teacher.
        /// </summary>
        /// <returns></returns>
        protected    override string Profession()
        {
            string profession = "Teacher";
            return profession;
        }
    }
}
