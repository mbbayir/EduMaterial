using EduMaterial.Models;
using EduMaterial.ViewModels;
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

        [HttpGet]
        public async Task<JsonResult> GetAllCourses(CourseViewModel course)
        {
            var courses = await _context.Courses
                .Include(c => c.CategoryCourses)
                .ThenInclude(cc => cc.Category)
                .ToListAsync();

            var courseViewModels = courses.Select(c => new CourseViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                DurationInHours = c.DurationInHours,
                Filepath = c.Filepath,
                FileSize = c.FileSize,
                //CategoryIds = c.CategoryCourses != null ? c.CategoryCourses.Select(cc => cc.CategoryId).ToList() : new List<int>()
            }).ToList();

            return Json(courseViewModels);
        }

        [HttpPost]
        public async Task<JsonResult> AddCourse(CourseViewModel course)
        {
            Course CourseADD = new Course();
            CourseADD.DurationInHours = course.DurationInHours;
            CourseADD.Name =course.Name;
            CourseADD.Description =course.Description;
            CourseADD.Filepath = course.Filepath;
            CourseADD.FileSize = course.FileSize;
            var data = _context.Courses.Add(CourseADD);
            await _context.SaveChangesAsync();



            foreach (var categoryıd in course.CategoryIds)
            {
                _context.CategoryCourses.Add(new CategoryCourse { CategoryId = categoryıd, CourseId = CourseADD.Id });
              
            }

            await _context.SaveChangesAsync();

            return Json(course);
        }

    }
}
