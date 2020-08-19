using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniNext.Context;
using MiniNext.Models;

namespace MiniNetf
{
    public class DocumentalController : Controller
    {
        private readonly MiniFlixDatabaseContext _context;

        public DocumentalController(MiniFlixDatabaseContext context)
        {
            _context = context;
        }

        // GET: Documental
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documentales.ToListAsync());
        }

        // GET: Documental/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documental = await _context.Documentales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documental == null)
            {
                return NotFound();
            }

            return View(documental);
        }

        // GET: Documental/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeneroDocumental,Descripcion,ImageFile,Imageroute,Id,Nombre,Abono")] Documental documental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documental);
        }

        // GET: Documental/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documental = await _context.Documentales.FindAsync(id);
            if (documental == null)
            {
                return NotFound();
            }
            return View(documental);
        }

        // POST: Documental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GeneroDocumental,Descripcion,ImageFile,Imageroute,Id,Nombre,Abono")] Documental documental)
        {
            if (id != documental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentalExists(documental.Id))
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
            return View(documental);
        }

        // GET: Documental/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documental = await _context.Documentales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documental == null)
            {
                return NotFound();
            }

            return View(documental);
        }

        // POST: Documental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documental = await _context.Documentales.FindAsync(id);
            _context.Documentales.Remove(documental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentalExists(int id)
        {
            return _context.Documentales.Any(e => e.Id == id);
        }
    }
}
