using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public BorrarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearContactoVM ContactoVm { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVm = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = await _contexto.Contacto.FindAsync(id)
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var Contacto = await _contexto.Contacto.FindAsync(ContactoVm.Contacto.Id);

            if (Contacto == null)
            {
                return NotFound();
            }

            _contexto.Contacto.Remove(Contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");

        }

    }
}
