namespace EduMaterial.Models
{
    public class Instructor : BaseEntity
    {
        public string Name { get; set; }

        //Bir eğitmenin birden fazla kursu olabilir
        public ICollection<InstructorCourse> Courses { get; set; }
    }
}
