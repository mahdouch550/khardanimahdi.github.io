using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Resources;
using System.Web;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class RemovedAgePropertyFromTimelineContentModel : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemovedAgePropertyFromTimelineContentModel));

        string IMigrationMetadata.Id => "202402151425591_RemovedAgePropertyFromTimelineContentModel";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            DropColumn("dbo.TimelineContents", "Age");
        }

        public override void Down()
        {
            AddColumn("dbo.TimelineContents", "Age", (ColumnBuilder c) => c.Int(false));
        }
    }
}