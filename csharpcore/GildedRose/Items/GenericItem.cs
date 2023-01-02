using System;

namespace GildedRose.Items
{
    public class GenericItem : Item
    {
        public int Attack {get; protected set;}
        public int Defense {get; protected set;}

        public GenericItem(string name, int sellIn, int quality, int basePrice, int Attack, int Defense) :base(name, sellIn, quality, basePrice)
        {
            this.Attack = Attack;
            this.Defense = Defense;
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
            this.quality--;

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