using ObjectOrientedPrograms.InventoryManagement;
const string INVENTORY_DATA_FILE_PATH = @"D:\RFP\PP\ObjectOrientedPrograms\ObjectOrientedPrograms\InventoryManagement\Inventory.json";
while (true)
{
    Console.WriteLine("\n Select Program\n 1.Inventory Management");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Inventory inventory = new Inventory();
            inventory.ReadJsonFile(INVENTORY_DATA_FILE_PATH);
            break;
    }
}