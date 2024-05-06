using PersonalHotspot.Areas.Management.Data;
using PersonalHotspot.Areas.Management.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PersonalHotspot.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PersonalHotspotDBContext>
    {
        public Configuration()
        {
            base.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonalHotspotDBContext context)
        {
            if (context.PersonalHotspotResumes.Count() == 0)
            {
                context.PersonalHotspotResumes.Add(new PersonalHotspotResume());
                context.SaveChanges();
            }
            if (context.HomeContents.Count() > 0)
            {
                context.PersonalHotspotResumes.ToList().LastOrDefault().HomeContent = context.HomeContents.ToList().LastOrDefault();
            }
            if (context.AboutContents.Count() > 0)
            {
                context.PersonalHotspotResumes.ToList().LastOrDefault().AboutContent = context.AboutContents.ToList().LastOrDefault();
            }
            if (context.TitleScoreSkills.Count() > 0)
            {
                context.PersonalHotspotResumes.ToList().LastOrDefault().TitleScoreSkills = context.TitleScoreSkills.ToList();
            }
            if (context.TitleDescriptionSkills.Count() > 0)
            {
                context.PersonalHotspotResumes.ToList().LastOrDefault().TitleDescriptionSkills = context.TitleDescriptionSkills.ToList();
            }
            if (context.TimelineContents.Count() > 0)
            {
                context.PersonalHotspotResumes.ToList().LastOrDefault().TimelineContents = context.TimelineContents.ToList();
            }
            context.SaveChanges();
        }
    }
}