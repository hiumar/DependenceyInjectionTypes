using System;
using System.Collections.Generic;

namespace DependenceyInjectionTypes
{
    class Program
    {
        static void Main(string[] args)
        {
           
            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer(new StudentDataAccessLayer());

            var result=studentBusinessLayer.GetStudents();
            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " " + item.studentId);
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }

    public class Student{
        public int studentId { get; set; }
        public string Name { get; set; }
     }
    public interface IStudentDataAccessLayer
    {
        List<Student> GetStudents();
    }
    public class StudentDataAccessLayer : IStudentDataAccessLayer
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { studentId = 1, Name = "Umar" });
            students.Add(new Student { studentId = 1, Name = "faraz" }); 
            students.Add(new Student { studentId = 1, Name = "Ahmed" });
            students.Add(new Student { studentId = 1, Name = "USman" });
            return students;
        }
    }
    public class StudentBusinessLayer
    {
        private readonly IStudentDataAccessLayer _studentDataAccessLayer;
        public StudentBusinessLayer(IStudentDataAccessLayer studentDataAccessLayer)
        {
            this._studentDataAccessLayer = studentDataAccessLayer;
        }

        public List<Student> GetStudents()
        {
            return _studentDataAccessLayer.GetStudents();
        }
    }
}
