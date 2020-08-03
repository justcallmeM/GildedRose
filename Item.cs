using System;
using System.Dynamic;

namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        //public ItemClass Class { get; set; }
        //public enum ItemClass
        //{
        //    Normal,
        //    Legendary,
        //    Passes,
        //    Conjured
        //}

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }
}
