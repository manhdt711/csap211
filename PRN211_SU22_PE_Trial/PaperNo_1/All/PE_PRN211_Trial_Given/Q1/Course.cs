using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        private Dictionary<Student, double> studentGPAList;

        public event Action<int, int> OnNumberOfStudentChange;

        public Course(int courseID, string courseTitle)
        {
            CourseID = courseID;
            CourseTitle = courseTitle;
            studentGPAList = new Dictionary<Student, double>();
        }

        public void AddStudent(Student student, double gpa)
        {
            studentGPAList[student] = gpa;
            OnNumberOfStudentChange?.Invoke(studentGPAList.Count - 1, studentGPAList.Count);
        }

        public void RemoveStudent(int studentID)
        {
            var studentToRemove = studentGPAList.Keys.FirstOrDefault(s => s.StudentID == studentID);
            if (studentToRemove != null)
            {
                studentGPAList.Remove(studentToRemove);
                OnNumberOfStudentChange?.Invoke(studentGPAList.Count + 1, studentGPAList.Count);
            }
        }

        public override string ToString()
        {
            string studentGPAString = "";
            foreach (var studentGPA in studentGPAList)
            {
                studentGPAString += $"\n{studentGPA.Key.StudentID} - {studentGPA.Key.StudentName}: {studentGPA.Value}";
            }

            return $"Course ID: {CourseID}\nCourse Title: {CourseTitle}\nStudents and their GPA:{studentGPAString}";
        }
    }
}
