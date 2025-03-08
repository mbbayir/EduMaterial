using EduMaterial.Models;
using EduMaterial.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EduMaterial.Controllers
{
    public class PanelController : Controller
    {
        private readonly AppDbContext _context;

        public PanelController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                TotalCategories = _context.Categories.Count(),
                TotalInstructors = _context.Instructors.Count(),
                TotalCourses = _context.Courses.Count(),
                TotalProducers = _context.Producers.Count()
            };
            return View(viewModel);
        }
    }
}
