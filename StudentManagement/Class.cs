using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManagement
{
    class Course
    {
        // set private variables for each property 
        private string _number;
        private string _prefix;
        private string _name;
        private int _hours;
        private double _grade;

        public Course(string Number, string Prefix, string Name, int Hours, double Grade)

        {
            _number = Number;
            _prefix = Prefix;
            _name = Name;
            _hours = Hours;
            _grade = Grade;
        }

        // set public Vars for each property  
        public string Number { get { return _number; } set { _number = value; } }
        public string Prefix { get { return _prefix; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Hours { get { return _hours; } } 
        public double Grade { get { return _grade; } }

    }
}
