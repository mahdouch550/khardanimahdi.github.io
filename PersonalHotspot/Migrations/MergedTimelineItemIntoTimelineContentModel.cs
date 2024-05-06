using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class MergedTimelineItemIntoTimelineContentModel : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(MergedTimelineItemIntoTimelineContentModel));

        string IMigrationMetadata.Id => "202403241639210_MergedTimelineItemIntoTimelineContentModel";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            DropForeignKey("dbo.TimelineItems", "TimelineContent_Id", "dbo.TimelineContents");
            DropIndex("dbo.TimelineItems", new string[1] { "TimelineContent_Id" });
            AddColumn("dbo.TimelineContents", "Month", (ColumnBuilder c) => c.Int(false));
            AddColumn("dbo.TimelineContents", "Title", (ColumnBuilder c) => c.String());
            AddColumn("dbo.TimelineContents", "Subtitle", (ColumnBuilder c) => c.String());
            AddColumn("dbo.TimelineContents", "Paragraph", (ColumnBuilder c) => c.String());
            DropTable("dbo.TimelineItems");
        }

        public override void Down()
        {
            CreateTable("dbo.TimelineItems", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                Title = c.String(),
                Subtitle = c.String(),
                Paragraph = c.String(),
                TimelineContent_Id = c.Guid()
            }).PrimaryKey(t => t.Id);
            DropColumn("dbo.TimelineContents", "Paragraph");
            DropColumn("dbo.TimelineContents", "Subtitle");
            DropColumn("dbo.TimelineContents", "Title");
            DropColumn("dbo.TimelineContents", "Month");
            CreateIndex("dbo.TimelineItems", "TimelineContent_Id");
            AddForeignKey("dbo.TimelineItems", "TimelineContent_Id", "dbo.TimelineContents", "Id");
        }
    }
}