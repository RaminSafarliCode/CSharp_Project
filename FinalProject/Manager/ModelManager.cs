using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Manager
{
    internal class ModelManager
    {
        Model[] data = new Model[0];
        public bool CheckModelName(string name)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data != null)
                {
                    if (data[i].NameModel.ToLower() == name.ToLower())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void Add(Model entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void EditModelName(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdModel == value)
                {
                    Console.WriteLine("Change the model...");
                    againEdit:
                    string newModel = ScannerManager.ReadString("Enter the new model name: ");
                    CheckModelName(newModel);
                    if (CheckModelName(newModel) == false)
                    {
                        ScannerManager.PrintError("This name is already used!");
                        goto againEdit;
                    }
                    else
                    {
                        data[i].NameModel = data[i].NameModel.Replace(data[i].NameModel, newModel);
                        break;
                    }
                }
            }
        }
        public void EditModelBrand(int value, int newBrand)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdModel == value)
                {
                    Console.WriteLine("Change the model brand...");
                    data[i].IdBr = newBrand;
                    break;
                }
            }
        }
        public void GetSingleModel(int value)
        {
            string singleModel = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdModel == value)
                {
                    singleModel = $"Model ID: {data[i].IdModel} | Model name: {data[i].NameModel} | Brand ID: {data[i].IdBr} ";
                    break;
                }
            }
            Console.WriteLine("******************** Choosen model ********************");
            Console.WriteLine(singleModel);
        }
        public void Remove(Model entity)
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
        public Model[] GetAll()
        {
            return data;
        }
    }
}
