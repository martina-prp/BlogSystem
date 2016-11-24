namespace BlogSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment_Field_Rename : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "PostId_Id", newName: "Post_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_PostId_Id", newName: "IX_Post_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_Post_Id", newName: "IX_PostId_Id");
            RenameColumn(table: "dbo.Comments", name: "Post_Id", newName: "PostId_Id");
        }
    }
}
