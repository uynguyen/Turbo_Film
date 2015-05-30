namespace Turbo_Phim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DayRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DayRegister", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DayRegister");
        }
    }
}
