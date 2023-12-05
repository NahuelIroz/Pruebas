using GestionDeFuentes.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Context
{
    public class GestionDeFuentesContext : DbContext
    {
        public GestionDeFuentesContext(DbContextOptions<GestionDeFuentesContext>options):base(options)
        {
            
        }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public DbSet<FuenteFinanciamiento> FuenteFinanciamiento { get; set; }
        public DbSet<TipoFondo> TipoFondo { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Responsable> Responsable { get; set; }
    }
}
