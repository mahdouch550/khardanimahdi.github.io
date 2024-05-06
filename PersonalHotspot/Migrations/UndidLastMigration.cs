using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class UndidLastMigration : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(UndidLastMigration));

        string IMigrationMetadata.Id => "202312302058049_UndidLastMigration";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            DropForeignKey("dbo.TimelineContents", "TimelineItem_Id", "dbo.TimelineItems");
            DropIndex("dbo.TimelineContents", new string[1] { "TimelineItem_Id" });
            AddColumn("dbo.TimelineItems", "TimelineContent_Id", (ColumnBuilder c) => c.Guid());
            CreateIndex("dbo.TimelineItems", "TimelineContent_Id");
            AddForeignKey("dbo.TimelineItems", "TimelineContent_Id", "dbo.TimelineContents", "Id");
            DropColumn("dbo.TimelineContents", "TimelineItem_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.TimelineContents", "TimelineItem_Id", (ColumnBuilder c) => c.Guid());
            DropForeignKey("dbo.TimelineItems", "TimelineContent_Id", "dbo.TimelineContents");
            DropIndex("dbo.TimelineItems", new string[1] { "TimelineContent_Id" });
            DropColumn("dbo.TimelineItems", "TimelineContent_Id");
            CreateIndex("dbo.TimelineContents", "TimelineItem_Id");
            AddForeignKey("dbo.TimelineContents", "TimelineItem_Id", "dbo.TimelineItems", "Id");
        }
    }
}