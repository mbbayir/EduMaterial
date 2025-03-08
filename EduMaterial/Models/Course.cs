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
        public List<CourseTag> Tags { get; }

        public List<CategoryCourse> CategoryCourses { get; set; }

        //Bir kursun birden fazla eğitmeni olabilir
        public List<InstructorCourse> InstructorCourses { get; set; }

        public ICollection<CourseProducer> CourseProducers { get; set; }




    }
}
