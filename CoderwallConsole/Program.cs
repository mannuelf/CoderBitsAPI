using CoderWall.Controllers;
using CoderWall.Models;
using coderwall_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderwallConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BadgeModel> badges = new List<BadgeModel>();

            String userName = "yegengovender";

            CoderwallAPI CoderWallData = new CoderwallAPI(userName);

            for (int c = 0; c < CoderWallData.BadgeCount; c++)
            {
                badges.Add(new BadgeModel { Name = CoderWallData.Badges[c].name, Description = CoderWallData.Badges[c].description });
            }

            foreach (var badge in badges)
            {
                Console.WriteLine("Name: {0} , Description: {1} ", badge.Name, badge.Description);
            }

            Console.ReadLine();
        }
    }
}
