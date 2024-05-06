using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class AddedSocialMediaLinksPropertiesToHomeContentModel : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedSocialMediaLinksPropertiesToHomeContentModel));

        string IMigrationMetadata.Id => "202404261722175_AddedSocialMediaLinksPropertiesToHomeContentModel";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            AddColumn("dbo.HomeContents", "FacebookLink", (ColumnBuilder c) => c.String());
            AddColumn("dbo.HomeContents", "InstagramLink", (ColumnBuilder c) => c.String());
            AddColumn("dbo.HomeContents", "GithubLink", (ColumnBuilder c) => c.String());
            AddColumn("dbo.HomeContents", "LinkedinLink", (ColumnBuilder c) => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.HomeContents", "LinkedinLink");
            DropColumn("dbo.HomeContents", "GithubLink");
            DropColumn("dbo.HomeContents", "InstagramLink");
            DropColumn("dbo.HomeContents", "FacebookLink");
        }
    }

}