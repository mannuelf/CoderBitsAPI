using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderWall.Models
{
    public class CoderbitsModel
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public List<CoderBitsBadge> Badges { get; set; }

        public CoderbitsModel()
        {
            Badges = new List<CoderBitsBadge>();
        }

    }

    public class CoderBitsBadge {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public bool IsEarned { get; set; }
    }
}