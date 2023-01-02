using System;

namespace GildedRose.Items
{
    public class AgingItem : Item
    {
        public AgingItem(string name, int sellIn, int quality, int basePrice) : base(name, sellIn, quality, basePrice)
        {

        }

        public override int GetValue()
        {
            return this.basePrice + (this.quality * 10);
        }

        public override void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        private void UpdateQuality()
        {
            this.quality++;

            FloorQualityToZero();
            CeilQualityToFifty();
        }

        private void UpdateSellIn()
        {
            this.sellIn--;
            if (this.sellIn < 0)
                this.quality--;
        }
    }
}