using coderwall_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderWall.Models
{
    public class CoderwallEngine
    {
        private CoderwallAPI _coderWallData;

        public CoderwallEngine(string userName)
        {
            _coderWallData = new CoderwallAPI(userName);
        }

        public List<BadgeModel> GetBadges()
        {
            List<BadgeModel> badges = new List<BadgeModel>();

            for (int c = 0; c < _coderWallData.BadgeCount; c++)
            {
                badges.Add(new BadgeModel { Name = _coderWallData.Badges[c].name, Description = _coderWallData.Badges[c].description });
            }

            return badges;
        }

        public string GetFullName()
        {
            var fullName = _coderWallData.Name;
            return fullName;        
        }
    }
}