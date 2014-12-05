using System;
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
            if (item == null) 
                throw new ArgumentNullException("item");
            if (item.Quality < 0) 
                throw new ArgumentOutOfRangeException("item", "Quality of product is too low");

            // TBC Should the ranges for SulfurasHandOfRagnaros be checked?
            if (item.Name == Store.SulfurasHandOfRagnaros)
                return;

            if (item.Name == Store.AgedBrie || item.Name == Store.BackstagePassesToATafkal80etcConcert)
            {
                IncreaseQuality(item);
            }
            else
            {
                ReduceQuality(item);
            }

            item.SellIn = item.SellIn - 1;
            if (item.SellIn >= 0)
                return;

            UpdateQualityAfterSellByDate(item);
        }

        private static void UpdateQualityAfterSellByDate(Item item)
        {
            if (item.Name == Store.AgedBrie)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
            else
            {
                if (item.Name == Store.BackstagePassesToATafkal80etcConcert)
                {
                    item.Quality = item.Quality - item.Quality;
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality >= 50)
                return;

            item.Quality = item.Quality + 1;

            if (item.Name != Store.BackstagePassesToATafkal80etcConcert)
                return;

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

        private static void ReduceQuality(Item item)
        {
            if (item.Quality <= 0)
                return;
            
            item.Quality = item.Name == Store.ConjuredManaCake 
                ? item.Quality - 2 
                : item.Quality - 1;
        }
    }
}