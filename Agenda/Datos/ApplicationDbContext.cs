using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set;  }

        public DbSet<Contacto> Contacto { get; set; }

    }
}
