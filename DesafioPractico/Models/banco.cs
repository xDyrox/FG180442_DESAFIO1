namespace DesafioPractico.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class banco : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'banco' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'DesafioPractico.Models.banco' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'banco'  en el archivo de configuración de la aplicación.
        public banco()
            : base("name=banco")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<t_transaccion> tipoTransaccion { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<tcuenta> tipoCuentaBancaria { get; set; }
        public virtual DbSet<cuenta> cuentaBancaria { get; set; }
        public virtual DbSet<transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}