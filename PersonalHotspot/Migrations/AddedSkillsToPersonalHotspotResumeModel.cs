using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class AddedSkillsToPersonalHotspotResumeModel : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedSkillsToPersonalHotspotResumeModel));

        string IMigrationMetadata.Id => "202403051403517_AddedSkillsToPersonalHotspotResumeModel";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            AddColumn("dbo.TitleDescriptionSkills", "PersonalHotspotResume_Id", (ColumnBuilder c) => c.Guid());
            AddColumn("dbo.TitleScoreSkills", "PersonalHotspotResume_Id", (ColumnBuilder c) => c.Guid());
            CreateIndex("dbo.TitleDescriptionSkills", "PersonalHotspotResume_Id");
            CreateIndex("dbo.TitleScoreSkills", "PersonalHotspotResume_Id");
            AddForeignKey("dbo.TitleDescriptionSkills", "PersonalHotspotResume_Id", "dbo.PersonalHotspotResumes", "Id");
            AddForeignKey("dbo.TitleScoreSkills", "PersonalHotspotResume_Id", "dbo.PersonalHotspotResumes", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.TitleScoreSkills", "PersonalHotspotResume_Id", "dbo.PersonalHotspotResumes");
            DropForeignKey("dbo.TitleDescriptionSkills", "PersonalHotspotResume_Id", "dbo.PersonalHotspotResumes");
            DropIndex("dbo.TitleScoreSkills", new string[1] { "PersonalHotspotResume_Id" });
            DropIndex("dbo.TitleDescriptionSkills", new string[1] { "PersonalHotspotResume_Id" });
            DropColumn("dbo.TitleScoreSkills", "PersonalHotspotResume_Id");
            DropColumn("dbo.TitleDescriptionSkills", "PersonalHotspotResume_Id");
        }
    }
}