namespace CarDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCarNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "CarNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Owners", "CarNo");
        }
    }
}
