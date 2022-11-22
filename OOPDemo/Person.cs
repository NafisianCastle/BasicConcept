﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        protected abstract string Profession();
    }
}
