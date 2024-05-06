using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class ChangedTimeLineRelatedItems : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(ChangedTimeLineRelatedItems));

        string IMigrationMetadata.Id => "202402151158017_ChangedTimeLineRelatedItems";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            DropForeignKey("dbo.TitleDescriptionSkills", "TimelineItemWithSubItems_Id", "dbo.TimelineItems");
            DropIndex("dbo.TitleDescriptionSkills", new string[1] { "TimelineItemWithSubItems_Id" });
            AddColumn("dbo.TimelineItems", "Subtitle", (ColumnBuilder c) => c.String());
            AddColumn("dbo.TimelineItems", "Paragraph", (ColumnBuilder c) => c.String());
            DropColumn("dbo.TitleDescriptionSkills", "Discriminator");
            DropColumn("dbo.TitleDescriptionSkills", "TimelineItemWithSubItems_Id");
            DropColumn("dbo.TimelineItems", "Date");
            DropColumn("dbo.TimelineItems", "Description");
            DropColumn("dbo.TimelineItems", "Discriminator");
        }

        public override void Down()
        {
            AddColumn("dbo.TimelineItems", "Discriminator", (ColumnBuilder c) => c.String(false, 128));
            AddColumn("dbo.TimelineItems", "Description", (ColumnBuilder c) => c.String());
            AddColumn("dbo.TimelineItems", "Date", (ColumnBuilder c) => c.DateTime(false));
            AddColumn("dbo.TitleDescriptionSkills", "TimelineItemWithSubItems_Id", (ColumnBuilder c) => c.Guid());
            AddColumn("dbo.TitleDescriptionSkills", "Discriminator", (ColumnBuilder c) => c.String(false, 128));
            DropColumn("dbo.TimelineItems", "Paragraph");
            DropColumn("dbo.TimelineItems", "Subtitle");
            CreateIndex("dbo.TitleDescriptionSkills", "TimelineItemWithSubItems_Id");
            AddForeignKey("dbo.TitleDescriptionSkills", "TimelineItemWithSubItems_Id", "dbo.TimelineItems", "Id");
        }
    }
}