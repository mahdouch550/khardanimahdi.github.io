using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class ChangedListOfTimelineItemToSingleItem : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(ChangedListOfTimelineItemToSingleItem));

        string IMigrationMetadata.Id => "202312302053333_ChangedListOfTimelineItemToSingleItem";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            DropForeignKey("dbo.TimelineItems", "TimelineContent_Id", "dbo.TimelineContents");
            DropIndex("dbo.TimelineItems", new string[1] { "TimelineContent_Id" });
            AddColumn("dbo.TimelineContents", "TimelineItem_Id", (ColumnBuilder c) => c.Guid());
            CreateIndex("dbo.TimelineContents", "TimelineItem_Id");
            AddForeignKey("dbo.TimelineContents", "TimelineItem_Id", "dbo.TimelineItems", "Id");
            DropColumn("dbo.TimelineItems", "TimelineContent_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.TimelineItems", "TimelineContent_Id", (ColumnBuilder c) => c.Guid());
            DropForeignKey("dbo.TimelineContents", "TimelineItem_Id", "dbo.TimelineItems");
            DropIndex("dbo.TimelineContents", new string[1] { "TimelineItem_Id" });
            DropColumn("dbo.TimelineContents", "TimelineItem_Id");
            CreateIndex("dbo.TimelineItems", "TimelineContent_Id");
            AddForeignKey("dbo.TimelineItems", "TimelineContent_Id", "dbo.TimelineContents", "Id");
        }
    }

}