namespace EduMaterial.Models
{
    public class CourseProducer
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
