using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class DetalleModel : PageModel
    {

        private readonly ApplicationDbContext _contexto;

        public DetalleModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Contacto Contacto { get; set; }

        public async void OnGet(int id)
        {
            Contacto = await _contexto.Contacto
                             .Where(c => c.Id == id)
                             .Include(c => c.Categoria)
                             .FirstOrDefaultAsync();
        }
    }
}
