using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalHotspot.Areas.Management.Models
{
    public class HomeContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string ImageFileName { get; set; }

        public byte[] ImageByteArray { get; set; }

        public string GreetingLine { get; set; }

        public string FullName { get; set; }

        public string Summary { get; set; }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public string GithubLink { get; set; }

        public string LinkedinLink { get; set; }
    }
}