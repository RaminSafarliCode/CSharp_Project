using FinalProject.Infrustucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Manager
{
    internal class CarManager
    {
        Car[] data = new Car[0];
        public void Add(Car entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void EditCarModel(int value, int newModel)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdCar == value)
                {
                    Console.WriteLine("Change the car model...");
                    data[i].IdMo = newModel;
                    break;
                }
            }
        }
        public void EditYear(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdCar == value)
                {
                    Console.WriteLine("You are changing the release year of car...");
                    DateTime newYear = ScannerManager.ReadDate("Enter the new release year: ");
                    data[i].Year = newYear;
                    break;
                }
            }
        }
        public void EditPrice(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdCar == value)
                {
                    Console.WriteLine("You are changing the price of car...");
                    double newPrice = ScannerManager.ReadDouble("Enter the new price: ");
                    data[i].Price = newPrice;
                    break;
                }
            }
        }
        public void EditColor(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdCar == value)
                {
                    Console.WriteLine("You are changing the color of car...");
                    string newColor = ScannerManager.ReadString("Enter the new color: ");
                    data[i].Color = data[i].Color.Replace(data[i].Color, newColor);
                    break;
                }
            }
        }
        public void EditEngine(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdCar == value)
                {
                    Console.WriteLine("You are changing the engine of car...");
                    double newEngine = ScannerManager.ReadInteger("Enter the new engine: ");
                    data[i].Engine = newEngine;
                    break;
                }
            }
        }
        public void EditFuelType(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdCar == value)
                {
                    Console.WriteLine("You are changing the fuel type of car...");
                    FuelType numFuel = ScannerManager.ReadFuelMenu("Select the type of fuel: ");
                    switch (numFuel)
                    {
                        case FuelType.Gasoline:
                            data[i].FuelType = nameof(FuelType.Gasoline);
                            break;
                        case FuelType.Diesel:
                            data[i].FuelType = nameof(FuelType.Diesel);
                            break;
                        case FuelType.Hybrid:
                            data[i].FuelType = nameof(FuelType.Hybrid);
                            break;
                        case FuelType.Electro:
                            data[i].FuelType = nameof(FuelType.Electro);
                            break;
                        case FuelType.Gas:
                            data[i].FuelType = nameof(FuelType.Gas);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
        }
        public void GetSingleCar(int value)
        {
            string singleCar = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdCar == value)
                {
                    singleCar = $"Car ID: {data[i].IdCar} \n" +
                        $"Year: {data[i].Year :yyyy}\n" +
                        $"Price: {data[i].Price}$\n" +
                        $"Color: {data[i].Color}\n" +
                        $"Engine: {data[i].Engine}L\n" +
                        $"Fuel Type: {data[i].FuelType}\n" +
                        $"Model ID: {data[i].IdMo}";
                    break;
                }
            }
            Console.WriteLine("******************** Choosen car ********************");
            Console.WriteLine(singleCar);
        }
        public void Remove(Car entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
            {
                return;
            }
            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
            {
                Array.Resize(ref data, data.Length - 1);
            }
        }
        public Car[] GetAll()
        {
            return data;
        }
    }
}
