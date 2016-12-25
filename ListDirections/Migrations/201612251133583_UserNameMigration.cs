namespace ListDirections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Histories", "UserName", c => c.String(maxLength: 50, nullable: false, defaultValueSql: "system_user"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Histories", "UserName");
        }
    }
}
