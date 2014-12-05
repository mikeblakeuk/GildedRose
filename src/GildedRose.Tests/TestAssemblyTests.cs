using System.Collections.Generic;
using GildedRose.Console;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
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

        //[Test]
        //public void Conjured_items_degrade_in_Quality_twice_as_fast_as_normal_items()
        //{
        //    var item = new Item
        //    {
        //        Name = "Conjured Test",
        //        SellIn = 3,
        //        Quality = 6
        //    };

        //    var q = new QualityUpdater();
        //    q.UpdateItem(item);

        //    Assert.AreEqual(2, item.SellIn);
        //    Assert.AreEqual(5, item.Quality);
        //}
    }
}