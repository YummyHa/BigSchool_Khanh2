using System.Web.UI.WebControls;

namespace BigSchool_Khanh2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into categories (id, name) values (1, 'Development')");
            Sql("Insert into categories (id, name) values (2, 'Marketing')");
            Sql("Insert into categories (id, name) values (3, 'Business')");
        }
        
        public override void Down()
        {
        }
    }
}
