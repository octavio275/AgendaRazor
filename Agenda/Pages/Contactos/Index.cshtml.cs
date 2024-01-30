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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Contacto> Contactos { get; set; }


        public async Task OnGet()
        {
            Contactos = await _contexto.Contacto.Include(c => c.Categoria).ToListAsync();
        }
    }
}
