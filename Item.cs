using System;
using System.Dynamic;

namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; } // denotes the number of days we have to sell the item
        public int Quality { get; set; } // denotes how valuable the item is
        public ItemClass Class { get; set; }
        public enum ItemClass
        {
            Normal,
            Legendary,
            Passes,
            Conjured
        }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }
}
