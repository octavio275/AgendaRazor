using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Modelos.ViewModels
{
    public class CrearContactoVM
    {
        public List<Categoria> ListaCategorias { get; set; }
        public Contacto Contacto { get; set; }
    }
}
