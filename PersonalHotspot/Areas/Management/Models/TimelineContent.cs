using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalHotspot.Areas.Management.Models
{
    public class TimelineContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string Paragraph { get; set; }
    }
}