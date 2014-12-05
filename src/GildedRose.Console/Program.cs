using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    internal class Program
    {
        // ReSharper disable once InconsistentNaming
        private IList<Item> Items;

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            // IOC This
            var app = new Program
            {
                Items = new Store().LoadItems()
            };
            app.UpdateQuality();

            // TODO, save back to the store

            // Support for automation
            if(args.All(x => x != "/s"))
                System.Console.ReadKey();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void UpdateQuality()
        {
            var q = new QualityUpdater();
            q.UpdateQuality(Items);
        }
    }
}
