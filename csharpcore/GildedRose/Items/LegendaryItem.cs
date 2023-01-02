using System;

namespace GildedRose.Items
{
    public class LegendaryItem : Item
    {
        public int Attack {get; protected set;}
        public int Defense {get; protected set;}
        public LegendaryItem(string name, int sellIn, int quality, int basePrice, int Attack, int Defense) : base(name, sellIn, quality, basePrice)
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
        }
    }
}