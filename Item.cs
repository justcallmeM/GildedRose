using System;
using System.Dynamic;

namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        //Class property would definitely be added here, but ItemClass doesn't belong here, thus it would have to be placed somewhere else.

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
