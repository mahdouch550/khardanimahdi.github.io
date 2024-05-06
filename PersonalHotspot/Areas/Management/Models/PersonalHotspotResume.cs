using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalHotspot.Areas.Management.Models
{
    public class PersonalHotspotResume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual HomeContent HomeContent { get; set; }

        public virtual AboutContent AboutContent { get; set; }

        public virtual List<TitleDescriptionSkill> TitleDescriptionSkills { get; set; }

        public virtual List<TitleScoreSkill> TitleScoreSkills { get; set; }

        public virtual List<TimelineContent> TimelineContents { get; set; }
    }
}