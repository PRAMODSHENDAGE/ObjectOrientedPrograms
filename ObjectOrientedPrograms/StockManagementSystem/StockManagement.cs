using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.StockManagementSystem
{
    internal class StockManagement
    {
        List<Stock> stockList = new List<Stock>();
        List<Company> companyList = new List<Company>();

        public void ReadJsonFileStock(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                var json = reader.ReadToEnd();
                this.stockList = JsonConvert.DeserializeObject<List<Stock>>(json);
                Console.WriteLine("Name" + "\t" + "No Of Shares" + "\t" + "Price Per Share");
                foreach (var data in stockList)
                {
                    Console.WriteLine(data.Name + "\t" + data.NoOfShares + "\t" + data.PricePerShare);
                } 
            }
        }
        public void ReadJsonFileCompany(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                var json = reader.ReadToEnd();
                this.companyList = JsonConvert.DeserializeObject<List<Company>>(json);
                Console.WriteLine("Name" + "\t" + "No Of Shares" + "\t" + "Price Per Share");
                foreach (var data in companyList)
                {
                    Console.WriteLine(data.Symbol + "\t" + data.NoOfShares + "\t" + data.PricePerShare);
                }
            }
        }
        public void BuyCompanyShare(Company company)
        {
            bool flag = false;
            foreach (var companyDetails in companyList)
            {
                if (companyDetails.Symbol == company.Symbol)
                {
                    companyDetails.NoOfShares -= company.NoOfShares;
                    flag = true;
                }
            }
            foreach (var stockDetails in stockList)
            {
                if (stockDetails.Name == company.Symbol)
                {
                    stockDetails.NoOfShares -= company.NoOfShares;
                    flag = true;
                }
            }
            if (flag)
            {
                Stock stock = new Stock();
                stock.Name = company.Symbol;
                stock.NoOfShares = company.NoOfShares;
                stock.PricePerShare = company.PricePerShare;
                stockList.Add(stock);
            }
        }
        public void SellStockShares(Stock stock)
        {
            bool flag = false;
            foreach (var stockdetails in stockList)
            {
                if (stockdetails.Name == stock.Name)
                {
                    stockdetails.NoOfShares -= stock.NoOfShares;
                }
            }
            foreach (var companyDetails in companyList)
            {
                if (companyDetails.Symbol == stock.Name)
                {
                    companyDetails.NoOfShares += stock.NoOfShares;
                    flag = true;
                }
            }
            if (!flag)
            {
                Company company = new Company();
                company.Symbol = stock.Name;
                company.NoOfShares = stock.NoOfShares;
                company.PricePerShare = stock.PricePerShare;
                companyList.Add(company);
            }
        }
        public void WriteToJsonStock(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.stockList);
            Console.WriteLine("Name" + "\t" + "NoOfShare" + "\t" + "PricePerShare");
            foreach (var data in stockList)
            {
                Console.WriteLine(data.Name + "\t\t" + data.NoOfShares + "\t\t" + data.PricePerShare);
            }
            File.WriteAllText(filePath, json);
        }
        public void WriteToJsonCompany(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.companyList);
            Console.WriteLine("Symbol" + "\t" + "NoOfShare" + "\t" + "PricePerShare");
            foreach (var data in companyList)
            {
                Console.WriteLine(data.Symbol + "\t\t" + data.NoOfShares + "\t\t" + data.PricePerShare);
            }
            File.WriteAllText(filePath, json);
        }
    }
}
