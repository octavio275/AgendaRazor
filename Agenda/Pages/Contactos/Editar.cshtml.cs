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
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
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
            if (ModelState.IsValid)
            {
                var ContactoDesdeDb = await _contexto.Contacto.FindAsync(ContactoVm.Contacto.Id);
                ContactoDesdeDb.Nombre = ContactoVm.Contacto.Nombre;
                ContactoDesdeDb.Email = ContactoVm.Contacto.Email;
                ContactoDesdeDb.Telefono = ContactoVm.Contacto.Telefono;
                ContactoDesdeDb.CategoriaId = ContactoVm.Contacto.CategoriaId;
                ContactoDesdeDb.FechaCreacion = ContactoVm.Contacto.FechaCreacion;
                
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }

        }
    }
}
