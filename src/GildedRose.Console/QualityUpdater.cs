using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose
{
    public class QualityUpdater
    {
        public void UpdateQuality(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                UpdateItem(item);
            }
        }

        public void UpdateItem(Item item)
        {
            if (item.Name != Store.AgedBrie && item.Name != Store.BackstagePassesToATafkal80etcConcert)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != Store.SulfurasHandOfRagnaros)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == Store.BackstagePassesToATafkal80etcConcert)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != Store.SulfurasHandOfRagnaros)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn >= 0)
                return;

            if (item.Name != Store.AgedBrie)
            {
                if (item.Name != Store.BackstagePassesToATafkal80etcConcert)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Store.SulfurasHandOfRagnaros)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    item.Quality = item.Quality - item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}