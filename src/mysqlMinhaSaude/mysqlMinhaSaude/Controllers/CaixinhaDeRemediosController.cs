using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaSaude.Models;
using mysqlMinhaSaude.Models;

namespace mysqlMinhaSaude.Controllers
{
    public class CaixinhaDeRemediosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaixinhaDeRemediosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CaixinhaDeRemedios
        public async Task<IActionResult> Index()
        {
            return View(await _context.mysqlcsharpems.ToListAsync());
        }

        // GET: CaixinhaDeRemedios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caixinhaDeRemedios = await _context.mysqlcsharpems
                .FirstOrDefaultAsync(m => m.id == id);
            if (caixinhaDeRemedios == null)
            {
                return NotFound();
            }

            return View(caixinhaDeRemedios);
        }

        // GET: CaixinhaDeRemedios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaixinhaDeRemedios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,Tipo,Quantidade")] CaixinhaDeRemedios caixinhaDeRemedios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caixinhaDeRemedios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caixinhaDeRemedios);
        }

        // GET: CaixinhaDeRemedios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caixinhaDeRemedios = await _context.mysqlcsharpems.FindAsync(id);
            if (caixinhaDeRemedios == null)
            {
                return NotFound();
            }
            return View(caixinhaDeRemedios);
        }

        // POST: CaixinhaDeRemedios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,Tipo,Quantidade")] CaixinhaDeRemedios caixinhaDeRemedios)
        {
            if (id != caixinhaDeRemedios.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caixinhaDeRemedios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaixinhaDeRemediosExists(caixinhaDeRemedios.id))
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
            return View(caixinhaDeRemedios);
        }

        // GET: CaixinhaDeRemedios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caixinhaDeRemedios = await _context.mysqlcsharpems
                .FirstOrDefaultAsync(m => m.id == id);
            if (caixinhaDeRemedios == null)
            {
                return NotFound();
            }

            return View(caixinhaDeRemedios);
        }

        // POST: CaixinhaDeRemedios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caixinhaDeRemedios = await _context.mysqlcsharpems.FindAsync(id);
            _context.mysqlcsharpems.Remove(caixinhaDeRemedios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaixinhaDeRemediosExists(int id)
        {
            return _context.mysqlcsharpems.Any(e => e.id == id);
        }
    }
}
