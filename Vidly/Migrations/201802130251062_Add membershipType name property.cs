namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddmembershipTypenameproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("Update membershiptypes set Name = 'Pay as you Go' where id = 1");
            Sql("Update membershiptypes set Name = 'Monthly' where id = 2");
            Sql("Update membershiptypes set Name = 'Quarterly' where id = 3");
            Sql("Update membershiptypes set Name = 'Annually' where id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
