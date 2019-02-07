using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial.Data;
using Parcial.Models;

namespace Parcial.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrador,Ventas")]
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewData["NombreSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var productos = from pr in _context.Producto select pr;

            if (!string.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(pr => pr.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    productos = productos.OrderByDescending(p => p.Nombre);
                    break;
                default:
                    productos = productos.OrderBy(p => p.Nombre);
                    break;
            }
            int pageSize = 3;
            return View(await Paginacion<Producto>.CreateAsync(productos.AsNoTracking(), page ?? 1, pageSize));
        }

        
        public async Task<IActionResult> Mostrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.Provedor)
                .SingleOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        
        public IActionResult Nuevo()
        {
            ViewData["IdProvedor"] = new SelectList(_context.Provedor, "IdProvedor", "Nombre");
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nuevo([Bind("IdProducto,Nombre,PrecioUnitario,PrecioPublico,FechaFabricacion,FechaCaducaion,Iva,IdProvedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvedor"] = new SelectList(_context.Provedor, "IdProvedor", "Nombre", producto.IdProvedor);
            return View(producto);
        }

       
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.SingleOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdProvedor"] = new SelectList(_context.Provedor, "IdProvedor", "Nombre", producto.IdProvedor);
            return View(producto);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdProducto,Nombre,PrecioUnitario,PrecioPublico,FechaFabricacion,FechaCaducaion,Iva,IdProvedor")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProvedor"] = new SelectList(_context.Provedor, "IdProvedor", "Nombre", producto.IdProvedor);
            return View(producto);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.Provedor)
                .SingleOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var producto = await _context.Producto.SingleOrDefaultAsync(m => m.IdProducto == id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

   
    }
}
