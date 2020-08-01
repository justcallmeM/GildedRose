using System;
using System.Dynamic;

namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; } // denotes the number of days we have to sell the item
        public int Quality { get; set; } // denotes how valuable the item is
        //public ItemClass Class { get; set; }
        //[Flags] 
        //public enum ItemClass
        //{
        //    Normal = 1,
        //    Legendary = 1 << 1,
        //    Passes = 1 << 2,
        //    Conjured = 1 << 3
        //}

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }
}
