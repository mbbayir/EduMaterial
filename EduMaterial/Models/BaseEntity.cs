﻿namespace EduMaterial.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? EditingDate { get; set; }
    }
}