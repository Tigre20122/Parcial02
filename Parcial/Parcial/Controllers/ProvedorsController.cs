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
    public class ProvedorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvedorsController(ApplicationDbContext context)
        {
            _context = context;
        }
         [Authorize(Roles = "Administrador,Ventas")]
        


        public async Task<IActionResult> Index(string sortOrder,string searchString,string currentFilter,int? page)
        {
            ViewData["NombreSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var provedores = from p in _context.Provedor select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                provedores = provedores.Where(p => p.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    provedores = provedores.OrderByDescending(p => p.Nombre);
                    break;
                default:
                    provedores = provedores.OrderBy(p => p.Nombre);
                    break;
            }
            int pageSize = 3;
            return View(await Paginacion<Provedor>.CreateAsync(provedores.AsNoTracking(), page ?? 1, pageSize));
        }
        public async Task<IActionResult> Mostrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provedor = await _context.Provedor
                .SingleOrDefaultAsync(m => m.IdProvedor == id);
            if (provedor == null)
            {
                return NotFound();
            }

            return View(provedor);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nuevo([Bind("IdProvedor,Ruc,Nombre,Direccion,Telefono,Extencion,CelularContacto,NombreContacto")] Provedor provedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provedor);
        }


        public async   Task<List<Provedor>> MostrarAjax(int id)
        {
            List<Provedor> pros = new List<Provedor>();
            var appPro = await _context.Provedor.SingleOrDefaultAsync(pro => pro.IdProvedor == id);
            pros.Add(appPro);
            return pros;
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provedor = await _context.Provedor.SingleOrDefaultAsync(m => m.IdProvedor == id);
            if (provedor == null)
            {
                return NotFound();
            }
            return View(provedor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdProvedor,Ruc,Nombre,Direccion,Telefono,Extencion,CelularContacto,NombreContacto")] Provedor provedor)
        {
            if (id != provedor.IdProvedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(provedor);
        }

       
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provedor = await _context.Provedor
                .SingleOrDefaultAsync(m => m.IdProvedor == id);
            if (provedor == null)
            {
                return NotFound();
            }

            return View(provedor);
        }

      
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarELiminacion(int id)
        {
            var provedor = await _context.Provedor.SingleOrDefaultAsync(m => m.IdProvedor == id);
            _context.Provedor.Remove(provedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}
