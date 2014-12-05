using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Store
    {
        public const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredManaCake = "Conjured Mana Cake";

        public IList<Item> LoadItems()
        {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = SulfurasHandOfRagnaros, SellIn = 0, Quality = 80},
                new Item {Name = BackstagePassesToATafkal80EtcConcert, SellIn = 15, Quality = 20},
                new Item {Name = ConjuredManaCake, SellIn = 3, Quality = 6}
            };
        }
    }
}