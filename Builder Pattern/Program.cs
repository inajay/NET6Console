using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5,22.4,78.6,35.0),
                new FurnitureItem("Fan", 40.0, 22.22,10.6,9.0),
                new FurnitureItem("Air Purifier", 77.0, 29.22, 19.6, 79.0)

            };
            var inventoryBuilder = new DailyReportBuilder(items);
            //var director = new InventoryBuildDirector(inventoryBuilder);
            //director.BuildCompleteReport();
            //var directReport = inventoryBuilder.GetDailyReport();
            //Console.WriteLine(directReport.Debug());
            var fuentReport = inventoryBuilder
                .AddTitle()
                .AddDimesnsions()
                .AddLogistics(DateTime.Now)
                .GetDailyReport();
            Console.WriteLine(fuentReport.Debug());
            Console.ReadLine();
        }
    }
}
