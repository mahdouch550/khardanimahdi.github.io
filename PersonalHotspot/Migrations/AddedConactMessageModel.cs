using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Resources;

namespace PersonalHotspot.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed class AddedConactMessageModel : DbMigration, IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedConactMessageModel));

        string IMigrationMetadata.Id => "202404151139574_AddedConactMessageModel";

        string IMigrationMetadata.Source => null;

        string IMigrationMetadata.Target => Resources.GetString("Target");

        public override void Up()
        {
            CreateTable("dbo.ContactMessages", (ColumnBuilder c) => new
            {
                Id = c.Guid(false, identity: true),
                Name = c.String(),
                Email = c.String(),
                PhoneNumber = c.String(),
                Message = c.String(),
                Timestamp = c.DateTime(false),
                IpAddress = c.String(),
                IpAddressLocation = c.String()
            }).PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.ContactMessages");
        }
    }
}