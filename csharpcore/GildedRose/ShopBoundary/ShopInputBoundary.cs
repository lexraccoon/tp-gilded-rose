using System.Collections.Generic;

namespace GildedRose.ShopBoundary
{
    public interface ShopInputBoundary
    {
        void UpdateInventory();
        void SellItem(SellItemRequest request);
        decimal BidItem(SellItemRequest request);
    }

}