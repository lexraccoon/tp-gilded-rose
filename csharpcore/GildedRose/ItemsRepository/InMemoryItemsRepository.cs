using GildedRose.Items;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.ItemsRepository
{
    public class InMemoryItemsRepository : ItemsGateway
    {
        private IList<Item> items = new List<Item>(){
            new GenericItem("Wand", 10, 9, 2, 3, 1),
            new GenericItem("Sword", -1, 8, 3, 4, 1),
            new GenericItem("Shield", -1, 0, 1, 0, 5),
            new AgingItem("Aged Brie", 5, 4, 9),
            new AgingItem("Aged Brie", 5, 50, 15),
            new LegendaryItem("Sulfuras", 5, 80, 69, 10, 10),
            new RelicItem("RelicItem", 0, 0, 0),
            new EventItem("Backstage Pass", 15, 10, 99),
            new EventItem("Backstage Pass", 10, 10, 120),
            new EventItem("Backstage Pass", 5, 10, 150),
            new EventItem("Backstage Pass", -1, 10, 200),
            new ConjuredItem("Conjured", 5, 10, 666, 6, 4),
        };

        public Item FindItem(string type, int quality)
        {
            return GetInventory().FirstOrDefault(i => i.name == type && i.quality == quality);
        }

        public IList<Item> GetInventory()
        {
            return this.items;
        }

        public void SaveInventory(IList<Item> items)
        {
            this.items = items;
        }
    }
}