namespace BigSchool_Khanh2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoulumnIsCanceledToTableCourses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "isCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "isCanceled");
        }
    }
}
