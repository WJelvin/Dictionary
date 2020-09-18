namespace Dictionary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModelForFrescati : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TranslationKey = c.String(),
                        SV_Text = c.String(nullable: false),
                        EN_Text = c.String(nullable: false),
                        CurrentView = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Translations");
        }
    }
}
