using Newtonsoft.Json;
using ObjectOrientedPrograms.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.InventoryManagementSystem
{
    internal class InventoryFactory
    {
        InventoryManagement inventory = new InventoryManagement();
        public void ReadJsonFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.inventory = JsonConvert.DeserializeObject<InventoryManagement>(json);
                Display(this.inventory.RiceList, "RiceList");
                Display(this.inventory.WheatList, "WheatList");
                Display(this.inventory.PulsesList, "PulsesList");
            }
        }
        public void AddInventory(string inventoryName, InventoryDetails details)
        {
            if (inventoryName == "RiceList")
            {
                this.inventory.RiceList.Add(details);
                Display(this.inventory.RiceList, "RiceList");
            }
            if (inventoryName == "WheatList")
            {
                this.inventory.WheatList.Add(details);
                Display(this.inventory.WheatList, "WheatList");
            }
            if (inventoryName == "PulsesList")
            {
                this.inventory.PulsesList.Add(details);
                Display(this.inventory.RiceList, "PulsesList");
            }
        }
        public void DeleteInventory(string inventoryName, string inventoryDetailName)
        {
            if (inventoryName == "RiceList")
            {
                foreach (var data in this.inventory.RiceList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        this.inventory.RiceList.Remove(data);
                        Display(this.inventory.RiceList, "RiceList");
                        return;
                    }
                }
                Console.WriteLine("Inventory Details Does Not Exist");
            }
            if (inventoryName == "WheatList")
            {
                foreach (var data in this.inventory.WheatList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        this.inventory.WheatList.Remove(data);
                        Display(this.inventory.WheatList, "WheatList");
                        return;
                    }
                }
                Console.WriteLine("Inventory Details Does Not Exist");
            }
            if (inventoryName == "PulesesList")
            {
                foreach (var data in this.inventory.PulsesList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        this.inventory.PulsesList.Remove(data);
                        Display(this.inventory.PulsesList, "PulsesList");
                        return;
                    }
                }
                Console.WriteLine("Inventory Details Does Not Exist");
            }
        }
        public void EditInventory(string inventoryName, string inventoryDetailName)
        {
            Console.WriteLine("Select Item - [1.RiceList, 2.WheatList, 3.PulsesList] To Edit:");
            string InventoryDetail = Console.ReadLine();
            if (inventoryName == "RiceList")
            {
                Console.WriteLine("Enter the Variety Name To Edit: ");
                string RiceList = Console.ReadLine();
                foreach (var data in this.inventory.RiceList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        Console.WriteLine("To Edit Variety Enter 1.Weight 2.Price");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose Valid Option");
                                break;
                        }
                        Display(this.inventory.RiceList, "RiceList");
                    }
                }
            }
            if (inventoryName == "WheatList")
            {
                Console.WriteLine("Enter the Variety Name To Edit: ");
                string Name = Console.ReadLine();
                foreach (var data in this.inventory.WheatList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        Console.WriteLine("To Edit Variety Enter 1.Weight 2.Price");
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose Valid Option");
                                break;
                        }
                        Display(this.inventory.WheatList, "WheatList");
                    }
                }
            }
            if (inventoryName == "PulsesList")
            {
                Console.WriteLine("Enter the Variety Name To Edit: ");
                string Name = Console.ReadLine();
                foreach (var data in this.inventory.PulsesList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        Console.WriteLine("To Edit Variety Enter 1.Weight 2.Price");
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose Valid Option");
                                break;
                        }
                        Display(this.inventory.PulsesList, "PulsesList");
                    }
                }
                Console.WriteLine(" Display After Editing Variety\n");
            }
        }
        public void WriteToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.inventory);
            File.WriteAllText(filePath, json);
        }
        public void Display(List<InventoryDetails> list, string inventoryName)
        {
            Console.WriteLine("Inventory is:" + inventoryName);
            Console.WriteLine("Name" + "\t" + "Weight" + "\t" + "Price");
            foreach (var data in list)
            {
                Console.WriteLine(data.Name + "\t" + data.Weight + "\t" + data.Price);
            }
        }
    }
}
