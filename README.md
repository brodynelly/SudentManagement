STUDENT MANAGEMENT SYSTEM - M11 ASSIGNMENT
------------------------------------------

DESCRIPTION:
This WPF application is a simple Student Management System built on top of the provided starter project. It allows users to add, manage, and track undergraduate and graduate students, along with their enrolled courses and GPA calculations. The interface reflects expected academic standards, and all input is validated with proper error handling.

<img width="982" alt="Screenshot 2025-04-14 at 10 52 00 PM" src="https://github.com/user-attachments/assets/aea2efa2-9c66-4488-8cce-3c92d4e1e9ed" />


------------------------------------------
CORE FEATURES IMPLEMENTED:

1. CLASS HIERARCHY:
   - Inherited `UndergraduateStudent` and `GraduateStudent` classes from the base `Person` class.
   - Created a `Course` class with the following fields:
     - Course Name (string)
     - Course Prefix (string)
     - Course Number (int)
     - Grade (double: 0.0–4.0)

2. STUDENT MANAGEMENT:
   - Users can add new students via the input fields and "Add Student" button.
   - Students appear in the ListBox and are displayed in alphabetical order by Last Name, then First Name.
   - Selecting a student loads their profile details and associated course list.

3. COURSE MANAGEMENT:
   - Users can add courses to the selected student.
   - Course prefix and number determine valid course types:
     - Undergraduate: Course number between 1000–4999
     - Graduate: Course number between 5000–9999
   - GPA is automatically calculated as a weighted average and is read-only.
   - Selecting a course fills in course information for review or future editing.

4. VALIDATION & EXCEPTION HANDLING:
   - Validates that all course numbers are four-digit integers.
   - Ensures grades are between 0.0 and 4.0.
   - Validates appropriate course level for the selected student type.
   - Displays error messages via MessageBox when invalid input is detected.

5. LIST SORTING:
   - Students are sorted by Last Name, then First Name in the main list.
   - Courses are sorted by Course Prefix, then Course Number in the secondary list.

6. USER EXPERIENCE:
   - Clean, intuitive layout with grouped UI for students and course management.
   - Data binding is used to ensure real-time updates when interacting with student/course records.

------------------------------------------
BONUS FEATURES IMPLEMENTED:

✓ Save/Load (Serialization)
   - Users can save the current student list to a file and load it back on future runs.
   - Data is serialized using JSON and stored in a `.json` file.
   - Implemented via buttons: "Save Students" and "Load Students".

✓ Edit & Delete
   - Students and courses can be edited and deleted.
   - Selecting a student or course pre-fills the form for editing.
   - Delete buttons remove the selected student or course from the respective lists.

------------------------------------------
HOW TO USE:

1. Launch the application.
2. Add student info, choose Undergraduate or Graduate, then click "Add Student".
3. Select a student to view and manage their courses.
4. Add course info and click "Add Course".
5. GPA will auto-update based on added courses.
6. Use "Save" and "Load" buttons to persist student data across sessions.
7. Select a student/course and click "Edit" or "Delete" as needed.
8. Use "Clear" to reset form fields.

------------------------------------------
FILES INCLUDED:

- MainWindow.xaml / MainWindow.xaml.cs — UI and logic control
- Person.cs — Base class
- UndergraduateStudent.cs / GraduateStudent.cs — Derived classes
- Course.cs — Course data model
- TextDocument.cs (if included) — Model-view separation helper
- README.txt — This documentation file

------------------------------------------
REQUIREMENTS:

- .NET Desktop Runtime 6.0+
- Visual Studio 2022 or newer
- WPF Application Template

------------------------------------------
NOTES:

- All data validation occurs at the UI level with helpful user prompts.
- Exception handling wraps all file and input operations.
- The application mirrors the provided walkthrough video and sample UI design.

