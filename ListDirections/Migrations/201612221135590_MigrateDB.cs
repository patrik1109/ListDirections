namespace ListDirections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PreRequisites", "Instruction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PreRequisites", "Instruction");
        }
    }
}
