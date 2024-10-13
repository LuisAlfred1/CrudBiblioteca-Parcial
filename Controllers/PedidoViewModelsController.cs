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
    public class PedidoViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PedidoViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedidos.ToListAsync());
        }

        // GET: PedidoViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoViewModel = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoViewModel == null)
            {
                return NotFound();
            }

            return View(pedidoViewModel);
        }

        // GET: PedidoViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PedidoViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,Descripcion,Date")] PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoViewModel);
        }

        // GET: PedidoViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoViewModel = await _context.Pedidos.FindAsync(id);
            if (pedidoViewModel == null)
            {
                return NotFound();
            }
            return View(pedidoViewModel);
        }

        // POST: PedidoViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,Descripcion,Date")] PedidoViewModel pedidoViewModel)
        {
            if (id != pedidoViewModel.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoViewModelExists(pedidoViewModel.PedidoId))
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
            return View(pedidoViewModel);
        }

        // GET: PedidoViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoViewModel = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidoViewModel == null)
            {
                return NotFound();
            }

            return View(pedidoViewModel);
        }

        // POST: PedidoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoViewModel = await _context.Pedidos.FindAsync(id);
            if (pedidoViewModel != null)
            {
                _context.Pedidos.Remove(pedidoViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoViewModelExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
