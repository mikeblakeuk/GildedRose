using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    /// <summary>
    /// Only used to make sure the items are processed in a for loop
    /// </summary>
    public class QualityStoreTests
    {
        private readonly Store _store = new Store(); //Integration test :(

        [Test]
        public void When_Store_Is_Used_Items_Are_Processed()
        {
            var items = _store.LoadItems(); //Repository this?

            var q = new QualityUpdater();
            q.UpdateQuality(items);

            Assert.AreEqual(6, items.Count);
            // More assert here about products interacting with others?
        }

        [Test]
        public void When_Items_Has_Items_Then_Process()
        {
            var items = new List<Item>
            {
                new Item {Quality = 10, SellIn = 5}
            };

            var q = new QualityUpdater();
            q.UpdateQuality(items);

            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(9, items[0].Quality);
        }
    }
}