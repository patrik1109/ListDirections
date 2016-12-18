namespace ListDirections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StepOrderMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Shedules", newName: "Schedules");
            AddColumn("dbo.PreRequisites", "StepOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PreRequisites", "StepOrder");
            RenameTable(name: "dbo.Schedules", newName: "Shedules");
        }
    }
}
