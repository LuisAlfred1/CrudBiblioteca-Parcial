using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudBiblioteca.Data;
using CrudBiblioteca.Models;

namespace CrudBiblioteca.Controllers
{
    public class ProductoViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductoViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }

        // GET: ProductoViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoViewModel = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productoViewModel == null)
            {
                return NotFound();
            }

            return View(productoViewModel);
        }

        // GET: ProductoViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductoViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Nombre,Precio,Cantidad")] ProductoViewModel productoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productoViewModel);
        }

        // GET: ProductoViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoViewModel = await _context.Productos.FindAsync(id);
            if (productoViewModel == null)
            {
                return NotFound();
            }
            return View(productoViewModel);
        }

        // POST: ProductoViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Nombre,Precio,Cantidad")] ProductoViewModel productoViewModel)
        {
            if (id != productoViewModel.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoViewModelExists(productoViewModel.ProductoId))
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
            return View(productoViewModel);
        }

        // GET: ProductoViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoViewModel = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productoViewModel == null)
            {
                return NotFound();
            }

            return View(productoViewModel);
        }

        // POST: ProductoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoViewModel = await _context.Productos.FindAsync(id);
            if (productoViewModel != null)
            {
                _context.Productos.Remove(productoViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoViewModelExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
