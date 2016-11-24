namespace BlogSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
