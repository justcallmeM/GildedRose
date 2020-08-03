using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_LegendaryDoesntChange()
        {
            List<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            };

            GildedRose app = new GildedRose(Items);

            (int a, int b) quality = (Items[0].Quality, Items[1].Quality);
            (int a, int b) sellIn = (Items[0].SellIn, Items[1].SellIn);

            for(int i =  0; i < 30; i++)
            {
                app.UpdateQuality();

                Assert.AreEqual(quality.a, Items[0].Quality);
                Assert.AreEqual(quality.b, Items[1].Quality);

                Assert.AreEqual(sellIn.a, Items[0].SellIn);
                Assert.AreEqual(sellIn.b, Items[1].SellIn);
            }
        }

        [Test]
        public void UpdateQuality_BackstagePassesChangesAccordingly()
        {
            List<Item> Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
            };

            GildedRose app = new GildedRose(Items);

            List<Item> ItemsChanged = Items;

            for (int i = 0; i < 30; i++)
            {
                app.UpdateQuality();

                for(int j = 0; j < Items.Count; j++)
                {
                    Item item = ItemsChanged[j];

                    int newQuality = item.Quality switch
                    {
                        int q when q < 50 => item.SellIn switch
                        {
                            int sl when sl > 10 => item.Quality += 1,
                            int sl when sl > 5  => item.Quality += 2,
                            _                   => item.Quality += 3
                        },
                        _ => item.Quality
                    };

                    item.Quality = newQuality > 50 ? 50 : newQuality;

                    item.Quality = item.SellIn <= 0 ? item.Quality = 0 : item.Quality;

                    item.SellIn--;

                    Assert.AreEqual(ItemsChanged[j].Quality, Items[j].Quality);
                    Assert.AreEqual(ItemsChanged[j].SellIn, Items[j].SellIn);
                }
            }
        }

        [Test]
        public void UpdateQuality_NormalChangesAccordingly()
        {
            List<Item> Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            };

            GildedRose app = new GildedRose(Items);

            List<Item> ItemsChanged = Items;

            for (int i = 0; i < 30; i++)
            {
                app.UpdateQuality();

                for (int j = 0; j < Items.Count; j++)
                {
                    Item item = ItemsChanged[j];

                    int newQuality = item.Quality switch
                    {
                        int q when q > 0 => item.SellIn switch
                        {
                            int sl when sl > 0 => item.Quality--,
                            _                  => item.Quality -= 2
                        },
                        _ => item.Quality
                    };

                    item.Quality = newQuality < 0 ? 0 : newQuality;

                    item.SellIn--;

                    Assert.AreEqual(ItemsChanged[j].Quality, Items[j].Quality);
                    Assert.AreEqual(ItemsChanged[j].SellIn, Items[j].SellIn);
                }
            }
        }

        [Test]
        public void UpdateQuality_ConjureChangesAccordingly()
        {
            List<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            GildedRose app = new GildedRose(Items);

            List<Item> ItemsChanged = Items;

            for (int i = 0; i < 30; i++)
            {
                app.UpdateQuality();

                for (int j = 0; j < Items.Count; j++)
                {
                    Item item = ItemsChanged[j];

                    int newQuality = item.Quality switch
                    {
                        int q when q > 0 => item.SellIn switch
                        {
                            int sl when sl > 0 => item.Quality -= 2,
                            _                  => item.Quality -= 4
                        },
                        _ => item.Quality
                    };

                    item.Quality = newQuality < 0 ? 0 : newQuality;

                    item.SellIn--;

                    Assert.AreEqual(ItemsChanged[j].Quality, Items[j].Quality);
                    Assert.AreEqual(ItemsChanged[j].SellIn, Items[j].SellIn);
                }
            }
        }
    }
}
