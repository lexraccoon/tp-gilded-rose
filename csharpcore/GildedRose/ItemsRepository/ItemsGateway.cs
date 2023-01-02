using GildedRose.Items;
using System.Collections.Generic;

namespace GildedRose.ItemsRepository
{
    public interface ItemsGateway
    {
        IList<Item> GetInventory();
        void SaveInventory(IList<Item> items);

        Item FindItem(string type, int quality);
    }

}