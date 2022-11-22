using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public enum Departments
        {
            CSE,
            EEE,
            IPE,
            ME,
            CE
        }
    public class Data
    {

        private IClassroom _classroom;
        public Data(IClassroom classroom)
        {
            _classroom= classroom;
        }
        public void ClassInfo()
        {
            _classroom.ClassroomStart();
        }
    }
}
