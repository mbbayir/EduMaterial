using Microsoft.AspNetCore.Identity;

namespace EduMaterial.Models
{
    public class AppUser:IdentityUser
    {
        public  int Id {  get; set; }
        public string FullName { get; set; }

        public ICollection<Course> Courses { get; set; }


    }
}