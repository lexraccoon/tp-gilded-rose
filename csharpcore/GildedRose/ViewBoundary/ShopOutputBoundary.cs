using System.Collections.Generic;

namespace GildedRose.ViewBoundary
{
    public interface ShopOutputBoundary
    {
        void DisplayMenu();

        void DisplayInventory(IList<ItemResponse> inventory);

        void DisplayBalance(int balance);

        void DisplayInventoryUpdate();

        void DisplaySellItem();

        void DisplayBidItem();
        
        void DisplayResultBidItem(decimal resultBidItem);

    }

}