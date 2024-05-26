using EduMaterial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduMaterial.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        //Kategori Listesini Gösterdiğim alan
        public async Task<IActionResult> Index()
        {
            var categories= await _context.Categories.ToListAsync();
            return View(categories);
        }

        //Category Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.CategoryCourses)
                .ThenInclude(cc => cc.Course)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }

    }
}
