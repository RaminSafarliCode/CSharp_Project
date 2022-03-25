using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Model
    {
        static int counter = 0;
        public Model()
        {
            counter++;
            IdModel = counter;
        }
        public int IdModel { get; set; }
        public string NameModel { get; set; }
        public int IdBr { get; set; }
        public override string ToString()
        {
            return $"Model ID: {IdModel} | Model name: {NameModel} | Brand ID: {IdBr}";
        }
    }
}
