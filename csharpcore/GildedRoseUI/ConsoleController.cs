using System;
using System.Collections.Generic;
using GildedRose;
using GildedRose.Items;
using GildedRose.ItemsRepository;
using GildedRose.ShopBoundary;
namespace GildedRoseUI
{ 
    public class ConsoleController
    {
       private static ShopInputBoundary shop = new ShopInteractor(new InMemoryItemsRepository(), new ConsoleView());

        public static void Main(string[] args)
        {
            while(true)
            {
                ((ShopInteractor) shop).DisplayMenu();
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ((ShopInteractor) shop).DisplayInventory();
                        break;
                    case 2:
                        ((ShopInteractor) shop).DisplayBalance();

                        break;
                    case 3:
                        shop.UpdateInventory();
                        ((ShopInteractor) shop).DisplayInventory();
                        break;
                    case 4:
                        ((ShopInteractor) shop).DisplayInventory();
                        ((ShopInteractor) shop).DisplaySellItem();
                        Item itemToSell = ((ShopInteractor) shop).Inventory[Convert.ToInt32(Console.ReadLine()) - 1];
                        shop.SellItem(new SellItemRequest(itemToSell.name, itemToSell.quality));
                        ((ShopInteractor) shop).DisplayInventory();
                        break;
                    case 5:
                        ((ShopInteractor) shop).DisplayInventory();
                        ((ShopInteractor) shop).DisplayBidItem();
                        Item itemToBid = ((ShopInteractor) shop).Inventory[Convert.ToInt32(Console.ReadLine()) - 1];
                        decimal resultBidItem = shop.BidItem(new SellItemRequest(itemToBid.name, itemToBid.quality));
                        ((ShopInteractor) shop).DisplayResultBidItem(resultBidItem);
                        break;
                    case 6:
                        return;
                }
            }
        }

    }
}