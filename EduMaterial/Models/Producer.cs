namespace EduMaterial.Models
{
    public class Producer : BaseEntity
    {
        public string Name { get; set; }

        // Üreticinin sahip olduğu eğitimler
        public ICollection<CourseProducer> CourseProducers { get; set; }
    }
}
