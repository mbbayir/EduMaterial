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
        public JsonResult GetAllCourseJson()
        {

            try
            {
                var courses = _context.Courses
            .Include(c => c.CategoryCourses)
            .ThenInclude(cc => cc.Category)
            .Include(i => i.InstructorCourses).ThenInclude(i => i.Instructor)
            .Include(i => i.CourseProducers).ThenInclude(i => i.Producer)
            .Include(i => i.Tags)
            .ToList();

                return Json(courses);
            }
            catch (Exception ex)
            {

                return Json(ex.InnerException.Message);
            }
        
        }

        [HttpPost]
        public async Task<JsonResult> AddCourse(CourseViewModel course)
        {
            if (course == null || string.IsNullOrWhiteSpace(course.Name))
            {
                return Json(new { success = false, message = "Course details are invalid." });
            }

            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description,
                DurationInHours = course.DurationInHours,
                Filepath = course.Filepath,
                FileSize = course.FileSize,
               
            };

            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            if (course.CategoryIds != null && course.CategoryIds.Any())
            {
                foreach (var categoryId in course.CategoryIds)
                {
                    _context.CategoryCourses.Add(new CategoryCourse { CategoryId = categoryId, CourseId = newCourse.Id });
                }


            }

            if (course.InstructorIds != null && course.InstructorIds.Any())
            {
                foreach (var instructorId in course.InstructorIds)
                {
                    _context.InstructorCourses.Add(new InstructorCourse { InstructorId = instructorId, CourseId = newCourse.Id });
                }

      
            }
            
            if (course.ProducerIds != null && course.ProducerIds.Any())
            {
                foreach (var producerId in course.ProducerIds)
                {
                    _context.CourseProducers.Add(new CourseProducer { ProducerId = producerId, CourseId = newCourse.Id });
                }

            }
            await _context.SaveChangesAsync();


            return Json(new { success = true, course = newCourse });
        }




        [HttpGet]
        public async Task<JsonResult> GetAllInstructors()
        {
            var data = await _context.Instructors.ToListAsync();
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllProducers()
        {
            var data = await _context.Producers.ToListAsync();
            return Json(data);
        }
    }
}
