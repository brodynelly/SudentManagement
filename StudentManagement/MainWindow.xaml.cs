using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // global strings
        private List<Person> _students = new List<Person>();
        private Person _selectedStudent;

        // global variabled 
        private string _firstName; 
        private string _lastName;
        private int _id;
        private int _gender;
        private int age;
        private int _level; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(StudentIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(AgeTextBox.Text))
            {
                MessageBox.Show("Fill in all fields.", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(StudentIDTextBox.Text, out int id) ||
                !int.TryParse(AgeTextBox.Text, out int age))
            {
                MessageBox.Show("ID and Age must be numeric.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int genderIndex = GenderComboBox.SelectedIndex;
            string level = ((ComboBoxItem)LevelComboBox.SelectedItem).Content.ToString();

            if (_students.Exists(s => s.FirstName == FirstNameTextBox.Text && s.LastName == LastNameTextBox.Text))
            {
                MessageBox.Show("Student already exists.", "Duplicate", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Person student; 

            if (level == "Undergraduate")
            {
                student = new UndergraduateStudent(FirstNameTextBox.Text, LastNameTextBox.Text, genderIndex, age);
            }
            else
            {
                student = new GraduateStudent(FirstNameTextBox.Text, LastNameTextBox.Text, genderIndex, age);
            }

                _students.Add(student);
            StudentsListBox.Items.Add(student); // stores full object

            // Clear fields
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            StudentIDTextBox.Clear();
            AgeTextBox.Clear();
        }

        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = StudentsListBox.SelectedItem as Person;
            
            if (selectedStudent != null)
            {
                CoursessListBox.Items.Clear();
                foreach (var course in selectedStudent.Courses)
                {
                    CoursessListBox.Items.Add($"{course.Prefix} {course.Number} - {course.Name}");
                }

                TotalGPATextBox.Text = selectedStudent.GetGPA().ToString("0.00");
            }
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = StudentsListBox.SelectedItem as Person;

            if (selectedStudent == null)
            {
                MessageBox.Show("Please select a student first.", "No Student Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate input fields
            string courseName = CourseNameTextBox.Text.Trim();
            string coursePrefix = CoursePrefixTextBox.Text.Trim();
            string courseNumberStr = CourseNumberTextBox.Text.Trim();
            string creditHoursStr = CreditHoursTextBox.Text.Trim();
            string gradeStr = GPATextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(courseName) ||
                string.IsNullOrWhiteSpace(coursePrefix) ||
                string.IsNullOrWhiteSpace(courseNumberStr) ||
                string.IsNullOrWhiteSpace(creditHoursStr) ||
                string.IsNullOrWhiteSpace(gradeStr))
            {
                MessageBox.Show("All course fields must be filled.", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(courseNumberStr, out int courseNumber) ||
                !int.TryParse(creditHoursStr, out int creditHours) ||
                !double.TryParse(gradeStr, out double grade))
            {
                MessageBox.Show("Course number, credit hours, and grade must be double.", "Format Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Undergrad rule check
            if (selectedStudent is UndergraduateStudent && (courseNumber <= 1000 || courseNumber >= 4999))
            {
                MessageBox.Show("Undergraduates cannot take 5000+ level courses or courses less than 1000.", "Course Restriction", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Graduate student rule check 
            else if ( selectedStudent is GraduateStudent && (courseNumber >= 9999 || courseNumber <= 5000))
            {
                MessageBox.Show("Graduate stuends cannot take 10000+ level courses and courses less than 5000", "Course Restriction",  MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            // Create course
            Course newCourse = new Course(
                Number: courseNumberStr,
                Prefix: coursePrefix,
                Name: courseName,
                Hours: creditHours,
                Grade: grade
            );

            selectedStudent.Courses.Add(newCourse);

            // Refresh UI
            CoursessListBox.Items.Add($"{coursePrefix} {courseNumberStr} - {courseName}");
            TotalGPATextBox.Text = selectedStudent.GetGPA().ToString("0.00");

            // Clear input fields
            CourseNameTextBox.Clear();
            CoursePrefixTextBox.Clear();
            CourseNumberTextBox.Clear();
            CreditHoursTextBox.Clear();
            GPATextBox.Clear();
        }

        // These fields are optional now
        private void FirstNameTextBox_TextChanged(object sender, EventArgs e) =>
            _firstName = FirstNameTextBox.Text;

        private void LastNameTextBox_TextChanged(object sender, EventArgs e) =>
            _lastName = LastNameTextBox.Text;

        private void StudentIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(StudentIDTextBox.Text, out _id))
                MessageBox.Show("Try to input a valid ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void StudentsListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}