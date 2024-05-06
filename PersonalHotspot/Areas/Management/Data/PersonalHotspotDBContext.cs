using System.Data.Entity;
using PersonalHotspot.Areas.Management.Models;

namespace PersonalHotspot.Areas.Management.Data
{
    public class PersonalHotspotDBContext : DbContext
    {
        public DbSet<HomeContent> HomeContents { get; set; }

        public DbSet<AboutContent> AboutContents { get; set; }

        public DbSet<TitleDescriptionSkill> TitleDescriptionSkills { get; set; }

        public DbSet<TitleScoreSkill> TitleScoreSkills { get; set; }

        public DbSet<TimelineContent> TimelineContents { get; set; }

        public DbSet<PersonalHotspotResume> PersonalHotspotResumes { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        public PersonalHotspotDBContext()
            : base("PersonalHotspotDBCS")
        {
        }
    }
}