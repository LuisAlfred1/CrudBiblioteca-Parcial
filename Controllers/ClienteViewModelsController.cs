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
    public class ClienteViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClienteViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: ClienteViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        // GET: ClienteViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nombre,CorreoElectronico,Telefono")] ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteViewModel);
        }

        // GET: ClienteViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await _context.Clientes.FindAsync(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        // POST: ClienteViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nombre,CorreoElectronico,Telefono")] ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteViewModelExists(clienteViewModel.ClienteId))
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
            return View(clienteViewModel);
        }

        // GET: ClienteViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        // POST: ClienteViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteViewModel = await _context.Clientes.FindAsync(id);
            if (clienteViewModel != null)
            {
                _context.Clientes.Remove(clienteViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteViewModelExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
