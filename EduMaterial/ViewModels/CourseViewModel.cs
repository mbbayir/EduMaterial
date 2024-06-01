using EduMaterial.Models;

namespace EduMaterial.ViewModels
{
    public class CourseViewModel:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DurationInHours { get; set; }
        public string? Filepath { get; set; }
        public long FileSize { get; set; } // Dosya boyutu 

        public int[] CategoryIds { get; set; }
    }
}
