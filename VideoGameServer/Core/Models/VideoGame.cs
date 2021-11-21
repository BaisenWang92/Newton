using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameServer.Core.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Publisher")]
        [Required]
        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
        [Required]
        public GameType GameType { get; set; }
        public virtual ICollection<VideoGamePlatform> VideoGamePlatforms { get; set; }
    }
}
