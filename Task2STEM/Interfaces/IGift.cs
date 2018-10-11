using Task2STEM.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2STEM.Interfaces
{
   public interface IGift
    {
        IEnumerable<ISweetness> Items { get; }
        IEnumerable<ISweetness> SortSweetnessByWeight();
        IEnumerable<ISweetness> FindSweetnessBySugar(double min, double max);
        string GiftName { get; }
        void AddSweet(Sweet sweets);
        void RemoveSweet(Sweet sweet);
        int CountOfSweet { get; }
        double GiftWeight { get; }
    }
}
