using EduMaterial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduMaterial.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [Route("Category/{id}")]
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var category = await _context.Categories
                .Include(c=>c.CategoryCourses)
                .ThenInclude(cc=>cc.Course)
                .FirstOrDefaultAsync(c=>c.Id == id);

            if(category == null)
            {
                return NotFound();
            }


            return View(category);
        }
        public async Task<IActionResult> AllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

    }
}
