namespace EduMaterial.Models
{
    public class Course : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DurationInHours { get; set; }
        public string? Filepath { get; set; }
        public long FileSize { get; set; } // Dosya boyutu 

        //Bir kursun birden fazla tagı olabilir
        public ICollection<CourseTag> Tags { get; }

        public ICollection<CategoryCourse> CategoryCourses { get; set; }

        //Bir kursun birden fazla eğitmeni olabilir
        public ICollection<InstructorCourse> Instructors { get; set; }

        public ICollection<CourseProducer> CourseProducers { get; set; }




    }
}
