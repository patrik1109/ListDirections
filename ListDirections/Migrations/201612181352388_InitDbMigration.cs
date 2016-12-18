namespace ListDirections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDbMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessRights",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProcessID = c.Int(nullable: false),
                        UserName = c.String(maxLength: 50, nullable:false),
                        ReadOnly = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ProcessID)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SessionID = c.Int(nullable: false),
                        ProcessID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeFinish = c.DateTime(),
                        Success = c.Boolean(),
                        ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.SessionID)
                .Index(t => t.ProcessID)
                .Index(t => t.EventID)
                .Index(t => t.TimeStart);
            
            CreateTable(
                "dbo.MainProcesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, nullable:false),
                        WorkingDir = c.String(nullable:false),
                        FinalScript = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PreRequisites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProcessID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50, nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ProcessID);
            
            CreateTable(
                "dbo.Shedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProcessID = c.Int(nullable: false),
                        DayOfWeek = c.Int(),
                        DayOfMonth = c.Int(),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ProcessID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Shedules", new[] { "ProcessID" });
            DropIndex("dbo.PreRequisites", new[] { "ProcessID" });
            DropIndex("dbo.Histories", new[] { "TimeStart" });
            DropIndex("dbo.Histories", new[] { "EventID" });
            DropIndex("dbo.Histories", new[] { "ProcessID" });
            DropIndex("dbo.Histories", new[] { "SessionID" });
            DropIndex("dbo.AccessRights", new[] { "UserName" });
            DropIndex("dbo.AccessRights", new[] { "ProcessID" });
            DropTable("dbo.Shedules");
            DropTable("dbo.PreRequisites");
            DropTable("dbo.MainProcesses");
            DropTable("dbo.Histories");
            DropTable("dbo.AccessRights");
        }
    }
}
