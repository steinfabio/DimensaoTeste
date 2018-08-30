namespace DimensaoTeste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskList1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        Situacao = c.Boolean(nullable: false),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskLists", "Usuario_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TaskLists", new[] { "Usuario_Id" });
            DropTable("dbo.TaskLists");
        }
    }
}
