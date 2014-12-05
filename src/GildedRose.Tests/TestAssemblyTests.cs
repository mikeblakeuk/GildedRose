using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class QualityUpdaterTests
    {
        private readonly Store _store = new Store();

        [Test]
        public void Baseline_test()
        {
            var items = _store.LoadItems(); //Repository this

            var q = new QualityUpdater();
            q.UpdateQuality(items);

            Assert.AreEqual(6, items.Count);
        }

        [Test]
        public void When_Other_Test()
        {
            var target = new Item { Name = null, Quality = 20, SellIn = 30 };

            var q = new QualityUpdater();
            q.UpdateItem(target);

            Assert.AreEqual(19, target.Quality);
            Assert.AreEqual(29, target.SellIn);
        }

        //The Quality of an item is never negative
        //TODO The Quality of an item is never more than 50 throw? or reset?

        /// <summary>
        /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        /// </summary>
        [Test]
        public void When_Sulfuras_Test()
        {
            var target = new Item {Name = Store.SulfurasHandOfRagnaros, Quality = 100, SellIn = 50};

            var q = new QualityUpdater();
            q.UpdateItem(target);

            Assert.AreEqual(100, target.Quality);
            Assert.AreEqual(50, target.SellIn);
        }


        /// <summary>
        /// "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        [Test]
        public void When_AgedBrie_Test()
        {
            var target = new Item { Name = Store.AgedBrie, Quality = 20, SellIn = 50 };

            var q = new QualityUpdater();
            q.UpdateItem(target);

            Assert.AreEqual(21, target.Quality);
            Assert.AreEqual(49, target.SellIn);
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

            var q = new QualityUpdater();
            q.UpdateItem(item);

            Assert.AreEqual(2, item.SellIn);
            Assert.AreEqual(5, item.Quality);
        }
    }
}