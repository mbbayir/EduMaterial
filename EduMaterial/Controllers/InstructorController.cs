    using EduMaterial.Models;
using EduMaterial.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduMaterial.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _context;

        public InstructorController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Instructor = await _context.Instructors.ToListAsync();
            return View(Instructor);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _context.Instructors.ToListAsync();

            return Json(instructors);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .Include(i => i.Courses)
                    .ThenInclude(ic => ic.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            // Null koleksiyon kontrolü
            if (instructor.Courses == null)
            {
                instructor.Courses = new List<InstructorCourse>();
            }

            return View(instructor);
        }


        public IActionResult Created()
        {
            var instructors = _context.Instructors.ToList();
            return View(instructors);
        }


        [HttpPost]
        public async Task<IActionResult> Created(Instructor instructor)
        {
            _context.Add(instructor);
            await _context.SaveChangesAsync();
            return Json("Kayıt Başarılı");
        }

    }
}
