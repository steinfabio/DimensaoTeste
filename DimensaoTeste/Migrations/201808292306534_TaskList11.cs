namespace DimensaoTeste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskList11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskLists", "Titulo", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskLists", "Titulo", c => c.String());
        }
    }
}
