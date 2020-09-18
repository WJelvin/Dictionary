namespace Dictionary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Translations", "SV_Text", c => c.String());
            AlterColumn("dbo.Translations", "EN_Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Translations", "EN_Text", c => c.String(nullable: false));
            AlterColumn("dbo.Translations", "SV_Text", c => c.String(nullable: false));
        }
    }
}
