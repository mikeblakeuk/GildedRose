using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    /// <summary>
    /// Only used to make sure the items are processed in a for loop
    /// </summary>
    public class DurationTests
    {
        private readonly Store _store = new Store(); //Integration test :(

        [Test]
        public void When_Store_Is_Used_Items_Are_Processed()
        {
            var q = new QualityUpdater();
            var items = _store.LoadItems(); //Repository this?

            var dayData = new List<DayData>(items.Count);

            for (int i = 0; i < 30; i++)
            {
                dayData.AddRange(items.Select(item => 
                    new DayData { Day = i, Name = item.Name, Quality = item.Quality, SellIn = item.SellIn }));
                q.UpdateQuality(items);                
            }

            foreach (var data in dayData)
            {
                System.Console.WriteLine(data.AsCsv());
            }
            //Paste this in to excel and run as a pivotchart

        }
    }

    public class DayData
    {
        public int Day { private get; set; }
        public int Quality { private get; set; }
        public int SellIn { private get; set; }
        public string Name { private get; set; }

        public string AsCsv()
        {
            //TODO Escape or use a real NuGet package
            return string.Format("{0},'{1}',{2},{3}", Day, Name.Replace(",",""), Quality, SellIn);
        }
    }
}