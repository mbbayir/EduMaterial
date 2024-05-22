namespace EduMaterial.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        //bir etikete birden fazla kurs atanabilir
        public ICollection<CourseTag> CourseTags { get; set; }
    }
}
