namespace GildedRose.Items
{
    public class ConjuredItem : Item
    {
        public int Attack {get; protected set;}
        public int Defense {get; protected set;}
        public ConjuredItem(string name, int sellIn, int quality, int basePrice, int Attack, int Defense) : base(name, sellIn, quality, basePrice)
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