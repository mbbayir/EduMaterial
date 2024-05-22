namespace EduMaterial.Models
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        
        public ICollection<CategoryCourse> CategoryCourses { get; set; }
    }
}
