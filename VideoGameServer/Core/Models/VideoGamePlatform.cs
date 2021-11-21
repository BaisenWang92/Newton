using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameServer.Core.Models
{
    public class VideoGamePlatform
    {
        public int VideoGameId { get; set; }
        [ForeignKey("VideoGameId")]
        public virtual VideoGame VideoGame { get; set; }

        public int PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public virtual Platform Platform { get; set; }
    }
}
