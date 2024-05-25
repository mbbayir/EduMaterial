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

        public async Task<IActionResult> Index(int? categoryFilter, string searchFilter)
        {
            IQueryable<Course> courses = _context.Courses.Include(c => c.CategoryCourses).ThenInclude(cc => cc.Category);

            // Kategoriye göre filtreleme
            if (categoryFilter.HasValue)
            {
                courses = courses.Where(c => c.CategoryCourses.Any(cc => cc.Category.Id == categoryFilter.Value));
            }

            // Kurs adı veya açıklamasına göre arama
            if (!string.IsNullOrEmpty(searchFilter))
            {
                courses = courses.Where(c => c.Name.ToLower().Contains(searchFilter.ToLower()) || c.Description.ToLower().Contains(searchFilter.ToLower()));
            }

            // Kategorileri view'a aktar
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            ViewBag.SearchFilter = searchFilter;

            return View(await courses.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.CategoryCourses)
                .ThenInclude(cc => cc.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
