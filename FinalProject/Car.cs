using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Car
    {
        static int counter = 0;
        public Car()
        {
            counter++;
            IdCar = counter;
        }
        public int IdCar { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public string FuelType { get; set; }    
        public int IdMo { get; set; }
        public override string ToString()
        {
            return $"Model ID: {IdMo} | ID: {IdCar} | Release Year: {Year: yyyy} | Price: {Price}$ | Color: {Color} | Engine: {Engine}L | Fuel type: {this.FuelType}";
        }
    }
}
