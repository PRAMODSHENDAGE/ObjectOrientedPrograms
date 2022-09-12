using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.InventoryManagement
{
    internal class Inventory
    {
        List<InventoryDetails> details = new List<InventoryDetails>();
        public void ReadJsonFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                var json = reader.ReadToEnd();

                this.details = JsonConvert.DeserializeObject<List<InventoryDetails>>(json);
                Console.WriteLine("Name" + "\t" + "Weight" + "\t" + "Price" + "\t" + "PricePerKg");
                foreach (var data in details)
                {
                    Console.WriteLine(data.Name + "\t" + data.Weight + "\t" + data.Price + "\t" + data.Price / data.Weight);
                }
            }
        }
    }
}