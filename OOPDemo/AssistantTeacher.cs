using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class AssistantTeacher:Teacher
    {
        private int probationMonth;

        public void Set(int val)
        {
            probationMonth= val;
        }
        protected override string Profession()
        {
            var val =  base.Profession();
            return val;
            //string profession = "Assistant Teacher";
            //return profession;
        }

        public class TraineeAssistantTeacher : AssistantTeacher {

            public int Get()
            {
                return probationMonth;
            }

            public class ReservedTraineeAssistantTeacher : TraineeAssistantTeacher
            {
                public int GetMonth()
                {
                    return probationMonth;
                }
            }
        }

    }
}
