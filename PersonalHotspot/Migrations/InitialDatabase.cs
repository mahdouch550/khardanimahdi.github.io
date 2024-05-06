using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class InitialDatabase : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(InitialDatabase));

        string IMigrationMetadata.Id => "202312292345047_InitialDatabase";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            CreateTable("dbo.AboutContents", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                ProfileTitle = c.String(),
                Technology = c.String(),
                Description = c.String(),
                YearsOfExperience = c.Int(false)
            }).PrimaryKey(t => t.Id);
            CreateTable("dbo.TitleDescriptionSkills", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                Description = c.String(),
                Title = c.String(),
                Discriminator = c.String(false, 128),
                AboutContent_Id = c.Guid(),
                TimelineItemWithSubItems_Id = c.Guid()
            }).PrimaryKey(t => t.Id).ForeignKey("dbo.AboutContents", t => t.AboutContent_Id).ForeignKey("dbo.TimelineItems", t => t.TimelineItemWithSubItems_Id)
                .Index(t => t.AboutContent_Id)
                .Index(t => t.TimelineItemWithSubItems_Id);
            CreateTable("dbo.TitleScoreSkills", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                Score = c.Int(false),
                Title = c.String(),
                AboutContent_Id = c.Guid()
            }).PrimaryKey(t => t.Id).ForeignKey("dbo.AboutContents", t => t.AboutContent_Id).Index(t => t.AboutContent_Id);
            CreateTable("dbo.HomeContents", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                ImageFileName = c.String(),
                ImageByteArray = c.Binary(),
                GreetingLine = c.String(),
                FullName = c.String(),
                Summary = c.String()
            }).PrimaryKey(t => t.Id);
            CreateTable("dbo.PersonalHotspotResumes", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                AboutContent_Id = c.Guid(),
                HomeContent_Id = c.Guid()
            }).PrimaryKey(t => t.Id).ForeignKey("dbo.AboutContents", t => t.AboutContent_Id).ForeignKey("dbo.HomeContents", t => t.HomeContent_Id)
                .Index(t => t.AboutContent_Id)
                .Index(t => t.HomeContent_Id);
            CreateTable("dbo.TimelineContents", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                Age = c.Int(false),
                Year = c.Int(false),
                PersonalHotspotResume_Id = c.Guid()
            }).PrimaryKey(t => t.Id).ForeignKey("dbo.PersonalHotspotResumes", t => t.PersonalHotspotResume_Id).Index(t => t.PersonalHotspotResume_Id);
            CreateTable("dbo.TimelineItems", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                Date = c.DateTime(false),
                Description = c.String(),
                Discriminator = c.String(false, 128),
                TimelineContent_Id = c.Guid()
            }).PrimaryKey(t => t.Id).ForeignKey("dbo.TimelineContents", t => t.TimelineContent_Id).Index(t => t.TimelineContent_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.TimelineContents", "PersonalHotspotResume_Id", "dbo.PersonalHotspotResumes");
            DropForeignKey("dbo.TimelineItems", "TimelineContent_Id", "dbo.TimelineContents");
            DropForeignKey("dbo.TitleDescriptionSkills", "TimelineItemWithSubItems_Id", "dbo.TimelineItems");
            DropForeignKey("dbo.PersonalHotspotResumes", "HomeContent_Id", "dbo.HomeContents");
            DropForeignKey("dbo.PersonalHotspotResumes", "AboutContent_Id", "dbo.AboutContents");
            DropForeignKey("dbo.TitleScoreSkills", "AboutContent_Id", "dbo.AboutContents");
            DropForeignKey("dbo.TitleDescriptionSkills", "AboutContent_Id", "dbo.AboutContents");
            DropIndex("dbo.TimelineItems", new string[1] { "TimelineContent_Id" });
            DropIndex("dbo.TimelineContents", new string[1] { "PersonalHotspotResume_Id" });
            DropIndex("dbo.PersonalHotspotResumes", new string[1] { "HomeContent_Id" });
            DropIndex("dbo.PersonalHotspotResumes", new string[1] { "AboutContent_Id" });
            DropIndex("dbo.TitleScoreSkills", new string[1] { "AboutContent_Id" });
            DropIndex("dbo.TitleDescriptionSkills", new string[1] { "TimelineItemWithSubItems_Id" });
            DropIndex("dbo.TitleDescriptionSkills", new string[1] { "AboutContent_Id" });
            DropTable("dbo.TimelineItems");
            DropTable("dbo.TimelineContents");
            DropTable("dbo.PersonalHotspotResumes");
            DropTable("dbo.HomeContents");
            DropTable("dbo.TitleScoreSkills");
            DropTable("dbo.TitleDescriptionSkills");
            DropTable("dbo.AboutContents");
        }
    }
}