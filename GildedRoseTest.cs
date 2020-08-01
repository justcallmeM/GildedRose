using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> 
            {
                //new Item { Name = "foo", SellIn = 0, Quality = 0 }
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            GildedRose app = new GildedRose(Items);

            IList<Item> ItemsEndResult = new List<Item>
            {
                //new Item { Name = "foo", SellIn = 0, Quality = 0 }
                new Item {Name = "+5 Dexterity Vest", SellIn = -20, Quality = 0 },
                new Item {Name = "Aged Brie", SellIn = -28, Quality = 50 },
                new Item {Name = "Elixir of the Mongoose", SellIn = -25, Quality = 0 },
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -15, Quality = 0 },
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -10, Quality = 0 },
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -25, Quality = 0 },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            //name, sellIn, quality
            //+ 5 Dexterity Vest, -20, 0
            //Aged Brie, -28, 50
            //Elixir of the Mongoose, -25, 0
            //Sulfuras, Hand of Ragnaros, 0, 80
            //Sulfuras, Hand of Ragnaros, -1, 80
            //Backstage passes to a TAFKAL80ETC concert, -15, 0
            //Backstage passes to a TAFKAL80ETC concert, -20, 0
            //Backstage passes to a TAFKAL80ETC concert, -25, 0
            //Conjured Mana Cake, -27, 0

            app.UpdateQuality();
            
            Assert.AreEqual(ItemsEndResult[0], Items[0]);
        }

        //potential tests
        //  At the end of each day our system lowers both values for every item
        //- Once the sell by date has passed, Quality degrades twice as fast
        //- The Quality of an item is never negative
        //- "Aged Brie" actually increases in Quality the older it gets
        //- The Quality of an item is never more than 50
        //- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        //- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        //- Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
        //- Quality drops to 0 after the concert

        //new functionality test
        //- "Conjured" items degrade in Quality twice as fast as normal items
    }
}
