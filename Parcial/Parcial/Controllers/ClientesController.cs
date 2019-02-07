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
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrador,Ventas,Cliente")]

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

            var clientes = from cl in _context.Clientes select cl;

            if (!string.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(cl => cl.Cedula.Contains(searchString)|| cl.Nombre.Contains(searchString)|| cl.Apellido.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    clientes = clientes.OrderByDescending(p => p.Nombre);
                    break;
                default:
                    clientes = clientes.OrderBy(p => p.Nombre);
                    break;
            }
            int pageSize = 3;
            return View(await Paginacion<Cliente>.CreateAsync(clientes.AsNoTracking(), page ?? 1, pageSize));
        }

      
        public async Task<IActionResult> Mostrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .SingleOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        
        public IActionResult Nuevo()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nuevo([Bind("IdCliente,Cedula,Nombre,Apellido,Direccion,Email,Celular")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdCliente,Cedula,Nombre,Apellido,Direccion,Email,Celular")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

       
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .SingleOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmandoEliminar(int id)
        {
            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.IdCliente == id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
