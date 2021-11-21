using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameServer.Core.Models
{
    public class VideoGameUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublisherId { get; set; }
        public GameType GameType { get; set; }
        public int[] PlatformIds { get; set; }
    }
}
