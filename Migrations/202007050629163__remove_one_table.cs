namespace doan_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _remove_one_table : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
    }
}
