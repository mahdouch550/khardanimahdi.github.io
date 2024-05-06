using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalHotspot.Areas.Management.Models
{
    public class AboutContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string ProfileTitle { get; set; }

        public string Technology { get; set; }

        public string Description { get; set; }

        public int YearsOfExperience { get; set; }

        public virtual List<TitleDescriptionSkill> TitleDescriptionSkills { get; set; }

        public virtual List<TitleScoreSkill> TitleScoreSkills { get; set; }
    }
}