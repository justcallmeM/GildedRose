using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_NormalItems()
        {
            List<Item> Items = new List<Item> 
            {
                //new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            List<Item> ItemsResult = new List<Item>
            {
                //new Item {Name = "+5 Dexterity Vest", SellIn = -20, Quality = 0},
                new Item {Name = "Aged Brie", SellIn = -28, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = -25, Quality = 0},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -15, Quality = 0},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -20, Quality = 0},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -25, Quality = 0},
                new Item {Name = "Conjured Mana Cake", SellIn = -27, Quality = 0},
            };

            GildedRose app = new GildedRose(Items);

            for(int i = 0; i < 30; i++)
            {
                app.UpdateQuality();
            }

            for(int i = 0; i<Items.Count; i++)
            {
                Assert.AreEqual(ItemsResult[i].Quality, Items[i].Quality);
                Assert.AreEqual(ItemsResult[i].SellIn, Items[i].SellIn);
            }
            
        }
    }
}
