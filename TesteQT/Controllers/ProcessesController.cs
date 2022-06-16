using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteQT.Date;
using TesteQT.Models;

namespace TesteQT.Controllers
{
    public class ProcessesController : Controller
    {
        private readonly Context _context;

        public ProcessesController(Context context)
        {
            _context = context;
        }

        // GET: Processes
        public async Task<IActionResult> Index()
        {
              return _context.Processe != null ? 
                          View(await _context.Processe.ToListAsync()) :
                          Problem("O contexto de proceso está vazio.");
        }

        // GET: Processes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProcessCode")] Process process)
        {
            if (ModelState.IsValid)
            {
                _context.Add(process);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Processo cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(process);
        }

        // GET: Processes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Processe == null)
            {
                return NotFound();
            }

            var process = await _context.Processe.FindAsync(id);
            if (process == null)
            {
                return NotFound();
            }
            return View(process);
        }

        // POST: Processes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcessCode")] Process process)
        {
            if (id != process.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(process);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Processo editado com sucesso";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessExists(process.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(process);
        }

        // GET: Processes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Processe == null)
            {
                return NotFound();
            }

            var process = await _context.Processe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (process == null)
            {
                return NotFound();
            }

            return View(process);
        }

        // POST: Processes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Processe == null)
            {
                return Problem("O processo está vazio.");
            }
            var process = await _context.Processe.FindAsync(id);
            if (process != null)
            {
                _context.Processe.Remove(process);
            }
            TempData["AlertMessage"] = "Processo deletado com sucesso";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessExists(int id)
        {
          return (_context.Processe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
