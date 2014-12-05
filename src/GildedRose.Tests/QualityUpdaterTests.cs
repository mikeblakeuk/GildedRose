using System;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class QualityUpdaterTests
    {
        [Test]
        public void When_Valid_Standard_Item_Then_Update()
        {
            var item = new Item { Quality = 20, SellIn = 30 };

            new QualityUpdater().UpdateItem(item);

            Assert.AreEqual(19, item.Quality);
            Assert.AreEqual(29, item.SellIn);
        }

        /// <summary>
        /// The Quality of an item is never negative
        /// </summary>
        [Test]
        public void When_Quality_Starts_Too_Low_Then_Throw()
        {
            var badItem = new Item { Quality = -1, SellIn = 1 };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new QualityUpdater().UpdateItem(badItem)
                );
        }

        /// <summary>
        /// The Quality of an item is never more than 50
        /// </summary>
        [Test]
        public void When_AgedBrie_Is_Max_Quality_Then_Do_Not_Increase_Quality()
        {
            var item = new Item { Name = Store.AgedBrie, Quality = 50, SellIn = 10 };

            new QualityUpdater().UpdateItem(item);

            Assert.AreEqual(50, item.Quality); //TBC, should this be 50?
            Assert.AreEqual(9, item.SellIn);
        }

        /// <summary>
        /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        /// </summary>
        [Test]
        public void When_Sulfuras_Test()
        {
            var item = new Item {Name = Store.SulfurasHandOfRagnaros, Quality = 100, SellIn = 50};

            new QualityUpdater().UpdateItem(item);

            Assert.AreEqual(100, item.Quality); //TBC, should this be 50?
            Assert.AreEqual(50, item.SellIn);
        }


        /// <summary>
        /// "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        [Test]
        public void When_AgedBrie_Test()
        {
            var item = new Item { Name = Store.AgedBrie, Quality = 20, SellIn = 50 };

            new QualityUpdater().UpdateItem(item);

            Assert.AreEqual(21, item.Quality);
            Assert.AreEqual(49, item.SellIn);
        }

        /// <summary>
        ///  "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; 
        /// Quality increases 
        /// by 2 when there are 10 days or less and 
        /// by 3 when there are 5 days or less 
        /// but Quality drops to 0 after the concert
        /// </summary>
        [Test]
        public void When_BackstagePassesToATafkal80etcConcert_Then_Correct()
        {
            var item = new Item { Name = Store.BackstagePassesToATafkal80etcConcert, Quality = 20, SellIn = 10 };

            new QualityUpdater().UpdateItem(item);

            Assert.AreEqual(22, item.Quality);
            Assert.AreEqual(9, item.SellIn);

            // TODO More tests around this
        }

        [Test]
        public void TODO_Conjured_items_degrade_in_Quality_twice_as_fast_as_normal_items()
        {
            var item = new Item
            {
                Name = "Conjured Test",
                SellIn = 3,
                Quality = 6
            };

            new QualityUpdater().UpdateItem(item);

            Assert.AreEqual(2, item.SellIn);
            Assert.AreEqual(5, item.Quality);
        }
    }
}