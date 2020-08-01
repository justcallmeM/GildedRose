using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;

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
                //int oldQuality = Items[i].Quality;
                //int newQualityEnum = Items[i].Class switch
                //{
                //    //when default: -1; sellin <= 10 =  -2; sellin >= 5 = -3; Quality can not be above 50;
                //    Item.ItemClass.Passes => Items[i].SellIn switch
                //    {
                //        int sl when sl > 10 => oldQuality + 1,
                //        int sl when sl > 5 => oldQuality + 2,
                //        int sl when sl > 0 => oldQuality + 3,
                //        _ => 0
                //    },
                //    Item.ItemClass.Conjured => Items[i].SellIn switch
                //    {
                //        int sl when sl >= 0 => oldQuality - 2,
                //        _ => oldQuality - 4
                //    },
                //    Item.ItemClass.Legendary => oldQuality,
                //    _ => oldQuality - 1
                //};

                //sellIn decreases logic

                int newQuality = Items[i] switch
                {
                    Item it when it.Name == "Aged Brie" || 
                                 it.Name == "Backstage passes to a TAFKAL80ETC concert" => it.SellIn switch
                    {
                        int sl when sl > 10 => it.Quality + 1,
                        int sl when sl > 5  => it.Quality + 2,
                        int sl when sl > 0  => it.Quality + 3,
                        _ => 0
                    },
                    Item it when it.Name == "Conjured Mana Cake" => it.SellIn switch
                    {
                        int sl when sl >= 0 => it.Quality - 2,
                        _ => it.Quality - 4
                    },
                    Item it when it.Name == "Sulfuras, Hand of Ragnaros" => it.Quality,
                    Item it => it.SellIn switch
                    {
                        int sl when sl >= 0 => it.Quality - 1,
                        _ => it.Quality - 2
                    }
                };



                if(Items[i].Name == "Aged Brie" || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    Items[i].Quality = newQuality > 50 ? 50 : newQuality;
                }
                else
                {
                    Items[i].Quality = newQuality > 0 ? newQuality : 0;
                }

                if(Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn--;
                }
            }
        }
    }

    public class ItemClassRules
    {
        public Item TreatAsNormal(Item item)
        {
            if(item.Quality > 0)
            {
                if (item.SellIn >= 0)
                {
                    item.Quality--;
                }
                else
                {
                    if (item.Quality > 0 && item.Quality != 1)
                    {
                        item.Quality -= 2;
                    }
                    else
                    {
                        item.Quality--;
                    }
                }
            }

            item.SellIn--;

            return item;
        }

        public Item TreatAsLegendary(Item item)
        {
            //- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality

            //"Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.

            return item;
        }

        public Item TreatAsBackstagePass(Item item)
        {
            //-The Quality of an item is never more than 50

            //"Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
            //  Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but


            if(item.Quality < 50) //not correct
            {
                //item.Quality
            }

            item.SellIn--;

            //  Quality drops to 0 after the concert
            if (item.SellIn >= 0)
            {
                item.Quality = 0;
            }

            return item;
        }

        public Item TreatAsCojured(Item item)
        {
            //- "Conjured" items degrade in Quality twice as fast as normal items

            //Once the sell by date has passed, Quality degrades twice as fast

            //The Quality of an item is never negative

            return item;
        }
    }


}
