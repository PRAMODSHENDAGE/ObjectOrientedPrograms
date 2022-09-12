using ObjectOrientedPrograms.InventoryManagement;
using ObjectOrientedPrograms.InventoryManagementSystem;
using ObjectOrientedPrograms.StockManagement;
using ObjectOrientedPrograms.StockManagementSystem;

const string INVENTORY_DATA_FILE_PATH = @"D:\RFP\PP\ObjectOrientedPrograms\ObjectOrientedPrograms\InventoryManagement\Inventory.json";
const string INVENTORYDETAILS_DATA_FILE_PATH = @"D:\RFP\PP\ObjectOrientedPrograms\ObjectOrientedPrograms\InventoryManagementSystem\InventoryDetails.json";
const string STOCKDETAILS_DATA_FILE_PATH = @"D:\RFP\PP\ObjectOrientedPrograms\ObjectOrientedPrograms\StockManagement\StockDetails.json";
const string COMPANY_DATA_FILE_PATH = @"D:\RFP\PP\ObjectOrientedPrograms\ObjectOrientedPrograms\StockManagementSystem\Company.json";
const string STOCK_DATA_FILE_PATH = @"D:\RFP\PP\ObjectOrientedPrograms\ObjectOrientedPrograms\StockManagementSystem\Stock.json";
while (true)
{
    Console.WriteLine("\n Select Program\n 1.Inventory Management\n 2.Inventory Management System\n 3.Stock Management\n 4.To Buy Shares\n 5.To Sell Stocks");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Inventory inventory = new Inventory();
            inventory.ReadJsonFile(INVENTORY_DATA_FILE_PATH);
            break;

        case 2:
            while (true)
            {
                Console.WriteLine("Select Option\n 1.Add List\n 2.Delete List\n 3.Edit List");
                int option1 = Convert.ToInt32(Console.ReadLine());
                switch (option1)
                {
                    case 1:
                        InventoryFactory factory = new InventoryFactory();
                        factory.ReadJsonFile(INVENTORYDETAILS_DATA_FILE_PATH);
                        InventoryDetails detail = new InventoryDetails()
                        {
                            Name = "Lokwan",
                            Weight = 10,
                            Price = 100
                        };
                        factory.AddInventory("WheatList", detail);
                        factory.WriteToJson(INVENTORYDETAILS_DATA_FILE_PATH);
                        Console.WriteLine("\n");
                        break;

                    case 2:
                        InventoryFactory factory1 = new InventoryFactory();
                        factory1.ReadJsonFile(INVENTORYDETAILS_DATA_FILE_PATH);
                        InventoryDetails detail1 = new InventoryDetails()
                        {
                            Name = "Wada",
                            Weight = 10,
                            Price = 300
                        };
                        factory1.DeleteInventory("RiceList", "Wada");
                        factory1.WriteToJson(INVENTORYDETAILS_DATA_FILE_PATH);
                        Console.WriteLine("\n");
                        break;

                    case 3:
                        InventoryFactory factory2 = new InventoryFactory();
                        factory2.ReadJsonFile(INVENTORYDETAILS_DATA_FILE_PATH);
                        factory2.EditInventory("WheatList", "Lokwan");
                        factory2.WriteToJson(INVENTORYDETAILS_DATA_FILE_PATH);
                        Console.WriteLine("\n");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        case 3:
            StockDetails stock = new StockDetails();
            stock.ReadJsonFile(STOCKDETAILS_DATA_FILE_PATH);
            break;

        case 4:
            StockManagement stockManagement = new StockManagement();
            stockManagement.ReadJsonFileCompany(COMPANY_DATA_FILE_PATH);
            stockManagement.ReadJsonFileStock(STOCK_DATA_FILE_PATH);
            Company company = new Company()
            {
                Symbol = "Amazon",
                NoOfShares = 10,
                PricePerShare = 80,
            };
            stockManagement.BuyCompanyShare(company);
            stockManagement.WriteToJsonCompany(COMPANY_DATA_FILE_PATH);
            stockManagement.WriteToJsonStock(STOCK_DATA_FILE_PATH);
            break;

        case 5:
            StockManagement stockManagement1 = new StockManagement();
            stockManagement1.ReadJsonFileCompany(COMPANY_DATA_FILE_PATH);
            stockManagement1.ReadJsonFileStock(STOCK_DATA_FILE_PATH);
            Stock stocks = new Stock()
            {
                Name = "Amazon",
                NoOfShares = 10,
                PricePerShare = 80,
            };
            stockManagement1.SellStockShares(stocks);
            stockManagement1.WriteToJsonCompany(COMPANY_DATA_FILE_PATH);
            stockManagement1.WriteToJsonStock(STOCK_DATA_FILE_PATH);
            break;
    }
}