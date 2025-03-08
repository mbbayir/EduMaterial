using EduMaterial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduMaterial.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Course Filter
        public async Task<IActionResult> Filter(int? categoryFilter, string searchFilter)
        {
            IQueryable<Course> courses = _context.Courses.Include(c => c.CategoryCourses).ThenInclude(cc => cc.Category);

            if (categoryFilter.HasValue)
            {
                courses = courses.Where(c => c.CategoryCourses.Any(cc => cc.Category.Id == categoryFilter.Value));
                ViewBag.SelectedCategory = categoryFilter.Value; 
            }

            if (!string.IsNullOrEmpty(searchFilter))
            {
                courses = courses.Where(c => c.Name.ToLower().Contains(searchFilter.ToLower()) || c.Description.ToLower().Contains(searchFilter.ToLower()));
            }

            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            return View(await courses.ToListAsync());
        }

        //Course Details
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
