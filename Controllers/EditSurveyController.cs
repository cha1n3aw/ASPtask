using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPtask.Data;
using ASPtask.Models;

namespace ASPtask.Controllers
{
    public class EditSurveyController : Controller
    {
        private readonly StudentsDB _context;

        public EditSurveyController(StudentsDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var question = await _context.Questions.FirstOrDefaultAsync(m => m.ID == id);
            if (question == null) return NotFound();
            return View(question);
        }
        public IActionResult TakeSurvey()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,QuestionContents,HasOptions,MultipleSelect,Options")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound();
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,QuestionContents,HasOptions,MultipleSelect,Options")] Question question)
        {
            if (id != question.ID) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.ID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var question = await _context.Questions.FirstOrDefaultAsync(m => m.ID == id);
            if (question == null) return NotFound();
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.ID == id);
        }
    }
}
