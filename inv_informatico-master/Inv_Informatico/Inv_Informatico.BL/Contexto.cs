using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv_Informatico.BL
{
  public  class Contexto: DbContext
    {
        public Contexto(): base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Inv_InformaticoDB.mdf")
        {
        
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());//Agregar datos de inicio a la BD al momento de crear.
        }

    

        public DbSet <Hardware> Hardware { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }

        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
