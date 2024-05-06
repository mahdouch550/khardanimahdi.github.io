using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class AddedTitlePropertyToTimelineItem : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedTitlePropertyToTimelineItem));

        string IMigrationMetadata.Id => "202312302048080_AddedTitlePropertyToTimelineItem";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            AddColumn("dbo.TimelineItems", "Title", (ColumnBuilder c) => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.TimelineItems", "Title");
        }
    }
}