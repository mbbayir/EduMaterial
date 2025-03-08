namespace EduMaterial.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CategoryCourse> CategoryCourses { get; set; }
    }
}
