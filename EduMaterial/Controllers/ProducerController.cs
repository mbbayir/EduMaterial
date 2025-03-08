using EduMaterial.Models;
using EduMaterial.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduMaterial.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppDbContext _context;

        public ProducerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var producer = await _context.Producers.ToListAsync();
            return View(producer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducers()
        {
            var producer = await _context.Producers.ToListAsync();

            return Json(producer);
        }

        public IActionResult Creat()
        {
            var producer = _context.Producers.ToList();
            return View(producer);
        }

        [HttpPost]

        public async Task<JsonResult> Creat(Producer producer)
        {
            _context.Add(producer);
            await _context.SaveChangesAsync();
            return Json("Kayıt Başarılı");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        [HttpPost]

        public async Task<JsonResult> Edit(int id, ProducerViewModel producer)
        {
            
            var data = await _context.Producers.FirstOrDefaultAsync(p=>p.Id == id);

            if (data == null)
            {
                return Json(new { success = false, message = "Producer bulunamadı" });
            }

            data.Name= producer.Name;
            await _context.SaveChangesAsync();
            return Json("Başarılı");
        }

        public async  Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer= await _context.Producers.FirstOrDefaultAsync(p=>p.Id==id);
            if(producer == null)
            {  return NotFound();}
            return View(producer);
        }

        [HttpPost  , ActionName("Delete")]
         public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            _context.Producers.Remove(producer);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
