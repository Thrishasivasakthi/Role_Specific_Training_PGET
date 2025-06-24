using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SessionInfo
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public int EventId { get; set; }
        public EventDetails Event { get; set; }

        [Required, StringLength(50)]
        public string SessionTitle { get; set; }

        public int? SpeakerId { get; set; }
        public SpeakerDetails? Speaker { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime SessionStart { get; set; }

        [Required]
        public DateTime SessionEnd { get; set; }

        public string? SessionUrl { get; set; }
    }

}
