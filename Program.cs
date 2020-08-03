using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        //This implementation lacks structure, thus to improve this design I'd create a class "Shop", which would be responsible for the daily refresh of the item values,
        //Shop would also have other useful methods that any game vendor would have. I'll try and create my final picture of the design, but in a separate project, because it no
        //longer would be refactoring, but instead a rewriting of the whole program.

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

            Console.ReadLine();
        }

        //Just include one additional parameter - Class
        //this will help the algorithm to be a lot cleaner by not having to compare names of the items

        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("OMGHAI!");

        //    IList<Item> Items = new List<Item>{
        //        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Class = Item.ItemClass.Normal},
        //        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0, Class = Item.ItemClass.Passes},
        //        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Class = Item.ItemClass.Normal},
        //        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Class = Item.ItemClass.Legendary},
        //        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Class = Item.ItemClass.Legendary},
        //        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Class = Item.ItemClass.Passes},
        //        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49, Class = Item.ItemClass.Passes},
        //        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49, Class = Item.ItemClass.Passes},
        //        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Class = Item.ItemClass.Conjured}
        //    };

        //    var app = new GildedRose(Items);

        //    for (var i = 0; i < 31; i++)
        //    {
        //        Console.WriteLine("-------- day " + i + " --------");
        //        Console.WriteLine("name, sellIn, quality");
        //        for (var j = 0; j < Items.Count; j++)
        //        {
        //            Console.WriteLine(Items[j]);
        //        }
        //        Console.WriteLine("");
        //        app.UpdateQuality();
        //    }
        //}
    }
}
