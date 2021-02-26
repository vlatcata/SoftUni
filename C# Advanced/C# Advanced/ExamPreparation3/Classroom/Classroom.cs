using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            data = new List<Student>();
        }

        public int Count { get { return data.Count; } }

        public int Capacity { get; set; }


        public string RegisterStudent(Student student)
        {
            if (data.Count < Capacity)
            {
                data.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstname, string lastname)
        {
            Student student = data.FirstOrDefault(s =>s.FirstName == firstname && s.LastName == lastname);
            if (data.Contains(student))
            {
                data.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            if (data.Any(s=>s.Subject == subject))
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");

                foreach (var student in data)
                {
                    if (student.Subject == subject)
                    {
                        sb.AppendLine($"{student.FirstName} {student.LastName}");
                    }
                }
                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return data.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return data.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
