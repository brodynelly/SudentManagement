using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    abstract class Person
    {
        private string firstName;
        private string lastName;
        private int gender; 
        // 0 for male, 1 for female, 2 for other
        private int age;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value ?? throw new ArgumentNullException(nameof(value), "First name cannot be null");
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value ?? throw new ArgumentNullException(nameof(value), "Last name cannot be null");
            }
        }

        public int Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public abstract List<Course> Courses { get; }
        public abstract double GetGPA();



    }
    // reference to Base class Person
    class UndergraduateStudent : Person
    {
        // can access Undergrad Courses
        private int _gpa;
        readonly List<Course> courses = new List<Course>();

        public override List<Course> Courses => courses;


        // create public class
        public UndergraduateStudent(string firstName, string lastName, int gender, int age)
        {
            FirstName = firstName; 
            LastName = lastName;
            Gender = Gender;
            Age = age; 
        }

        public void AddCourse(Course course)
        {
            // Possibly check for duplicates or do other validation
            courses.Add(course);
        }

        //function to create the courses for the student
        //public Course CreateCourse(string Number, string Prefix, string Name, int Hours, int Grade)
        //{
        //    Course newCourse = new Course(Number, Prefix, Name, Hours, Grade);
        //    return newCourse; 
        //}

        public List<Course> Course
        {
            get { return courses; }
        }


        public override double GetGPA()
        {
            if (courses.Count == 0) return 0;

            double total = 0;
            foreach (var course in courses)
                total += course.Grade;

            return total / courses.Count;
        }

        // return a list of students to display on the list of students
        public string DisplayInfo()
        {
            return $"{this.FirstName}" +
                $"{this.FirstName}" +
                $"{this.Age}";
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }


    }

    class GraduateStudent : Person
    {
        // can access grad classes
        //  // can access Undergrad Courses
        private int _gpa;
        readonly List<Course> courses = new List<Course>();
        public override List<Course> Courses => courses;


        // create public class
        public GraduateStudent(string firstName, string lastName, int gender, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = Gender;
            Age = age;
        }

        public void AddCourse(Course course)
        {
            // Possibly check for duplicates or do other validation
            courses.Add(course);
        }

        public Course CreateCourse(string Number, string Prefix, string Name, int Hours, int Grade)
        {
            Course newCourse = new Course(Number, Prefix, Name, Hours, Grade);
            return newCourse;
        }

        public List<Course> Course
        {
            get { return courses; }
        }

        public override double GetGPA()
        {
            if (courses.Count == 0) return 0;

            double total = 0;
            foreach (var course in courses)
                total += course.Grade;

            return total / courses.Count;
        }
        //return the Information about each student to display on the List of students 
        public string DisplayInfo()
        {
            return $"{this.FirstName}" +
                $"{this.FirstName}" +
                $"{this.Age}"; 
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    } 
}
