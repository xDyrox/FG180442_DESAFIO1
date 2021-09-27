namespace DesafioPractico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 200),
                        primerApellido = c.String(nullable: false, maxLength: 200),
                        segundoApellido = c.String(maxLength: 200),
                        telefono = c.String(nullable: false, maxLength: 20),
                        email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.cuenta",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cliente_id = c.Int(),
                        Moneda = c.String(nullable: false, maxLength: 20),
                        tipo_id = c.Int(),
                        clientes_id = c.Int(),
                        tipos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cliente", t => t.clientes_id)
                .ForeignKey("dbo.tcuenta", t => t.tipos_id)
                .Index(t => t.clientes_id)
                .Index(t => t.tipos_id);
            
            CreateTable(
                "dbo.tcuenta",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipo = c.String(nullable: false, maxLength: 200),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.t_transaccion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipo = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.transacciones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cuentaBancaria_id = c.Int(),
                        tipoTransaccion_id = c.Int(),
                        monto = c.Decimal(nullable: false, storeType: "money"),
                        Estado = c.String(nullable: false, maxLength: 200),
                        fechaTransaccion = c.DateTime(nullable: false),
                        fechaAplicacion = c.DateTime(nullable: false),
                        cuentas_id = c.Int(),
                        tipos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cuenta", t => t.cuentas_id)
                .ForeignKey("dbo.t_transaccion", t => t.tipos_id)
                .Index(t => t.cuentas_id)
                .Index(t => t.tipos_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transacciones", "tipos_id", "dbo.t_transaccion");
            DropForeignKey("dbo.transacciones", "cuentas_id", "dbo.cuenta");
            DropForeignKey("dbo.cuenta", "tipos_id", "dbo.tcuenta");
            DropForeignKey("dbo.cuenta", "clientes_id", "dbo.cliente");
            DropIndex("dbo.transacciones", new[] { "tipos_id" });
            DropIndex("dbo.transacciones", new[] { "cuentas_id" });
            DropIndex("dbo.cuenta", new[] { "tipos_id" });
            DropIndex("dbo.cuenta", new[] { "clientes_id" });
            DropTable("dbo.transacciones");
            DropTable("dbo.t_transaccion");
            DropTable("dbo.tcuenta");
            DropTable("dbo.cuenta");
            DropTable("dbo.cliente");
        }
    }
}
