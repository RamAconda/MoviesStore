namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenrelkptable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into GenreLkps (name) values ('Comedy')");
            Sql("insert into GenreLkps (name) values ('Action')");
            Sql("insert into GenreLkps (name) values ('Drama')");
            Sql("insert into GenreLkps (name) values ('Politics')");

        }
        
        public override void Down()
        {
        }
    }
}
