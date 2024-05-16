using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Checkpoint2DotNet_Biblioteca.Models;
using Checkpoint2DotNet_Biblioteca.Persistencia;

namespace Checkpoint2DotNet_Biblioteca.Controllers
{
    public class BibliotecasController : Controller
    {
        private readonly FiapDbContext _context;

        public BibliotecasController(FiapDbContext context)
        {
            _context = context;
        }

        // GET: Bibliotecas
        public async Task<IActionResult> Index()
        {
            var fiapDbContext = _context.Bibliotecas.Include(b => b.Endereco).Include(b => b.Livro);
            return View(await fiapDbContext.ToListAsync());
        }

        // GET: Bibliotecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Bibliotecas
                .Include(b => b.Endereco)
                .Include(b => b.Livro)
                .FirstOrDefaultAsync(m => m.BibliotecaId == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // GET: Bibliotecas/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "EnderecoId");
            ViewData["LivroId"] = new SelectList(_context.Livros, "LivroId", "Titulo");
            return View();
        }

        // POST: Bibliotecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BibliotecaId,Nome,EnderecoId,LivroId")] Biblioteca biblioteca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biblioteca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "EnderecoId", biblioteca.EnderecoId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "LivroId", "Titulo", biblioteca.LivroId);
            return View(biblioteca);
        }

        // GET: Bibliotecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Bibliotecas.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "EnderecoId", biblioteca.EnderecoId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "LivroId", "Titulo", biblioteca.LivroId);
            return View(biblioteca);
        }

        // POST: Bibliotecas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BibliotecaId,Nome,EnderecoId,Titulo")] Biblioteca biblioteca)
        {
            if (id != biblioteca.BibliotecaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biblioteca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliotecaExists(biblioteca.BibliotecaId))
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
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "EnderecoId", biblioteca.EnderecoId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "LivroId", "Titulo", biblioteca.LivroId);
            return View(biblioteca);
        }

        // GET: Bibliotecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Bibliotecas
                .Include(b => b.Endereco)
                .Include(b => b.Livro)
                .FirstOrDefaultAsync(m => m.BibliotecaId == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // POST: Bibliotecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biblioteca = await _context.Bibliotecas.FindAsync(id);
            if (biblioteca != null)
            {
                _context.Bibliotecas.Remove(biblioteca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotecaExists(int id)
        {
            return _context.Bibliotecas.Any(e => e.BibliotecaId == id);
        }
    }
}
