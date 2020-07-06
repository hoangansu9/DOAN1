namespace doan_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_sale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "UnitPriceSale", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "Qantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Qantity", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "UnitPriceSale");
            DropColumn("dbo.OrderDetails", "Quantity");
        }
    }
}
