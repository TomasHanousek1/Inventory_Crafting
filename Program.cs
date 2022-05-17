using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Inventory_Crafting
{
    class Program
    {

        static void Main(string[] args)
        {
            MyIDCollection.GetCollection();

            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                Console.WriteLine("D = dřevo, K = kámen, Ž = železo, !CRAFT");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "D":
                        Inventory.AddItem(Item.GetItem(1));
                        break;
                    case "K":
                        Inventory.AddItem(Item.GetItem(2));
                        break;
                    case "Ž":
                        Inventory.AddItem(Item.GetItem(3));
                        break;
                    case "!CRAFT":
                        break;
                    default:
                        Console.WriteLine("D = dřevo, K = kámen, Ž = železo, !CRAFT");
                        break;
                }

                foreach (var item in Inventory.MyInventory)
                {
                    Console.WriteLine(item.MyItem.Name + "|" + item.NumberOfItem); ;
                }
                Console.ReadLine();
            }

        }
    }

    public class MyIDCollection
    {
        public static ObservableCollection<Item> MyCollection { get; set; }
        public static void GetCollection()
        {
            MyCollection = new ObservableCollection<Item>(
                new Item[]
                {
                    new Item {Name = "Dřevo", ID = 1},
                    new Item {Name = "Kámen", ID = 2},
                    new Item {Name = "Železo", ID = 3},
                    new Item {Name = "Tyčka", ID = 211},
                    new Item {Name = "Kumpáč", ID = 243},

                }); ;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public static Item GetItem(int id)
        {
            Item myItem = new Item { Name = "NONE", ID = 0 };
            foreach (var item in MyIDCollection.MyCollection)
            {
                if (id == item.ID)
                    myItem = item;
            }
            return myItem;
        }
    }

    public class InventoryBlock
    {
        public Item MyItem { get; set; }
        public int NumberOfItem { get; set; }
    }

    public class Inventory
    {
        public static ObservableCollection<InventoryBlock> MyInventory = new ObservableCollection<InventoryBlock>();

        public static bool IsAlreadyHere(Item myitem, int numOfItems)
        {
            bool isHere = false;
            foreach (var item in MyInventory)
            {
                if (item.MyItem.ID == myitem.ID)
                {
                    isHere = true;
                    item.NumberOfItem += numOfItems;
                    break;
                }
            }
            return isHere;
        }

        /*public static int FindItemInInventory(int MyID)
        {
            int i = 0;
            foreach (var item in MyInventory)
            {
                if (item.MyItem.ID == MyID)
                {
                    i =
                }
            }
            return i;
        }*/

        public static void AddItem(Item myItem)
        {
            if (Inventory.IsAlreadyHere(myItem, 1) == false)
                Inventory.MyInventory.Add(new InventoryBlock { MyItem = myItem, NumberOfItem = 1 });
        }

        public static void AddMultiItem(Item myItem, int numOfItems)
        {
            if (Inventory.IsAlreadyHere(myItem, numOfItems) == false)
                Inventory.MyInventory.Add(new InventoryBlock { MyItem = myItem, NumberOfItem = numOfItems });
        }


        /*public static void CraftingDone(string s)
        {
            switch (s)
            {
                case "TYČKA":
                    if ()
                    {

                    }
                default:
                    break;
            }
        }*/
    }
}