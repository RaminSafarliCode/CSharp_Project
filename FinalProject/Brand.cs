using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Brand
    {
        static int counter = 0;
        public Brand()
        {
            counter++;
            IdBrand = counter;
        }
        public int IdBrand { get; set; }
        public string NameBrand { get; set; }
        public override string ToString()
        {
            return $"Brand ID: {IdBrand} | Brand name: {NameBrand}";
        }
    }
}
