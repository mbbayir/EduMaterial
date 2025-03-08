using EduMaterial.Models;
using EduMaterial.ViewModels;
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
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllCategories()
        {
            var categories= await _context.Categories.ToListAsync();
            return Json(categories);
        }

        //Category Details
        public async Task<IActionResult> Details(int id)
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

        public IActionResult Create()
        {
            var categories= _context.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public async Task<JsonResult> Create(Category category)
        {
           
            _context.Add(category);
            await _context.SaveChangesAsync();
            return Json("Kayıt Başarılı");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(int id, CategoryUpdateModel category)
        {
            
            var data= await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            
            data.Name=category.Name;
            await _context.SaveChangesAsync();
            return Json("Başarılı");
        }

        //Kategori Silme

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
