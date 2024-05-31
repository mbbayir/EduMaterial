using EduMaterial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduMaterial.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var courses = await _context.Courses
                .Include(c => c.CategoryCourses)
                .ThenInclude(cc => cc.Category)
                .ToListAsync();

            ViewBag.Categories = categories;
            return View(courses);
        }
        [HttpPost]
        public async Task<JsonResult> AddCourse(Course course, List<int> categoryIds)
        {
            course.CategoryCourses = categoryIds.Select(id => new CategoryCourse { CategoryId = id }).ToList();
            _context.Courses.Add(course);
            _context.SaveChangesAsync();

            return Json(course);
        }

    }
}
