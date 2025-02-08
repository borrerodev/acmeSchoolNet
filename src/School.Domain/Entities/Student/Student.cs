using School.Domain.Abstractions;
using School.Domain.Entities.Student.Events;

namespace School.Domain.Entities.Student;

    public class Student : Entity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Guid CourseId { get; set; }
        public School.Domain.Entities.Course.Course? Course { get; set; }
        private Student(Guid id, string name, int age) : base(id)
        {
            Name = name;    
            Age = age;
        }
        //public ICollection<Enrollment> Enrollments { get; set; }

        public static Student Create(string name, int age)
        {
            var student = new Student(new Guid(), name, age);
            student.RaiseDomainEvent(new StudentCreatedDomainEvent(student.Id));
            return student;
        }

        public static void AssignCourse(Student student, School.Domain.Entities.Course.Course course)
        {
            student.Course = course;
            student.CourseId = course.Id;
        }

    }
