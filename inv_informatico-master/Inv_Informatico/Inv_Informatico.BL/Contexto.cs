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
        }

    

    public  DbSet <Hardware> Hardware { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    }
}
