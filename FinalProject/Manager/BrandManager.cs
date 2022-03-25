using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Manager
{
    internal class BrandManager
    {
        Brand[] data = new Brand[0];

        public bool CheckBrandName(string name)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data != null)
                {
                    if (data[i].NameBrand.ToLower().Trim() == name.ToLower().Trim())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void Add(Brand entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);    
            data[len] = entity;
        }
        public void EditBrand(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdBrand == value)
                {
                    Console.WriteLine("Change the brand name...");
                    againEdit:
                    string newNameBrand = ScannerManager.ReadString("Enter the new brand name: ");
                    CheckBrandName(newNameBrand);
                    if (CheckBrandName(newNameBrand) == false)
                    {
                        ScannerManager.PrintError("This name is already used!");
                        goto againEdit;
                    }
                    else
                    {
                        data[i].NameBrand = data[i].NameBrand.Replace(data[i].NameBrand, newNameBrand);
                        break;
                    }
                }
            }
        }
        public void GetSingleBrand(int value)
        {
            string singleBrand = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdBrand == value)
                {
                    singleBrand = $"Brand ID: {data[i].IdBrand} | Brand name: {data[i].NameBrand} ";
                    break;
                }
            }
            Console.WriteLine("******************** Choosen brand ********************");
            Console.WriteLine(singleBrand);
        }
        public void Remove(Brand entity)
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
        public Brand[] GetAll()
        {
            return data;
        }
    }
}
