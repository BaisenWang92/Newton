using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameServer.Core.Models
{
    public class VideoGameResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Publisher Publisher { get; set; }
        public GameType GameType { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }
    }
}
