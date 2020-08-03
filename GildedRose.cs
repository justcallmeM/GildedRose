using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                int newQuality = Items[i] switch
                {
                    Item it when it.Name == "Sulfuras, Hand of Ragnaros" => it.Quality,
                    Item it when it.Name == "Conjured Mana Cake" => it.SellIn switch
                    {
                        int sl when sl > 0 => it.Quality - 2,
                        _ => it.Quality - 4
                    },
                    Item it when it.Name == "Aged Brie" ||
                                 it.Name == "Backstage passes to a TAFKAL80ETC concert" => it.SellIn switch
                                 {
                                     int sl when sl > 10 => it.Quality + 1,
                                     int sl when sl > 5 => it.Quality + 2,
                                     int sl when sl > 0 => it.Quality + 3,
                                     _ => 0
                                 },
                    Item it => it.SellIn switch
                    {
                        int sl when sl > 0 => it.Quality - 1,
                        _ => it.Quality - 2
                    }
                };

                if (Items[i].Name == "Aged Brie" || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    Items[i].Quality = newQuality > 50 ? 50 : newQuality;
                }
                else
                {
                    Items[i].Quality = newQuality > 0 ? newQuality : 0;
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn--;
                }
            }
        }

        //-------------------------------------------ADDITIONAL IMPLEMENTATIONS-------------------------------------------

        //-------------------------------------------SECOND IMPLEMENTATION------------------------------------------------
        //this method would be an improvement of the refactored method because it no longer compares the names of the items, but its class
        //this means thats not only the algorithm readability and maintainability improved, but we can work with an item class in other ways to improve
        //the overall design of the program.

        //public void UpdateQualityImproved()
        //{
        //    for (var i = 0; i < Items.Count; i++)
        //    {
        //        int oldQuality = Items[i].Quality;
        //        int sellIn = Items[i].SellIn;

        //        int newQuality = Items[i].Class switch
        //        {
        //            Item.ItemClass.Passes => sellIn switch
        //            {
        //                int sl when sl > 10 => oldQuality + 1,
        //                int sl when sl > 5 => oldQuality + 2,
        //                int sl when sl > 0 => oldQuality + 3,
        //                _ => 0
        //            },
        //            Item.ItemClass.Conjured => sellIn switch
        //            {
        //                int sl when sl > 0 => oldQuality - 2,
        //                _ => oldQuality - 4
        //            },
        //            Item.ItemClass.Legendary => oldQuality,
        //            _ => sellIn switch
        //            {
        //                int sl when sl > 0 => oldQuality - 1,
        //                _ => oldQuality - 2
        //            }
        //        };

        //        if (Items[i].Class == Item.ItemClass.Passes)
        //        {
        //            Items[i].Quality = newQuality > 50 ? 50 : newQuality;
        //        }
        //        else
        //        {
        //            Items[i].Quality = newQuality > 0 ? newQuality : 0;
        //        }

        //        if (Items[i].Class != Item.ItemClass.Legendary)
        //        {
        //            Items[i].SellIn--;
        //        }
        //    }
        //}
    }
}
