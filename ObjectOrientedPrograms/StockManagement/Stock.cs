using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.StockManagement
{
    internal class Stock
    {
        List<StockPortfolio> stocks = new List<StockPortfolio>();
        public void ReadJsonFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.stocks = JsonConvert.DeserializeObject<List<StockPortfolio>>(json);
                Console.WriteLine("StockName" + "\t" + "NoOfShares" + "\t" + "PricePerShare" + "\t" + "TotalValue");
                foreach (var data in stocks)
                {
                    Console.WriteLine(data.StockName + "\t\t" + data.NoOfShares + "\t\t" + data.PricePerShare + "\t\t" + data.NoOfShares * data.PricePerShare);
                }
            }
        }
    }
}