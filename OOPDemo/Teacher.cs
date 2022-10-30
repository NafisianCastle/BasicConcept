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

        protected override string Profession()
        {
            string profession = "Teacher";
            return profession;
        }
    }
}
