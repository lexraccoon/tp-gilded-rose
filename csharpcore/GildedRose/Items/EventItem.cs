using System;

namespace GildedRose.Items
{
    public class EventItem : Item
    {
        public EventItem(string name, int sellIn, int quality, int basePrice) : base(name, sellIn, quality, basePrice)
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

            if(this.sellIn <= 10)
                this.quality++;

            if(this.sellIn <= 5)
                this.quality++;

            if(this.sellIn < 0)
                this.quality = 0;

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