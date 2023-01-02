namespace GildedRose.Items
{
    public class RelicItem : Item
    {
        public RelicItem(string name, int sellIn, int quality, int basePrice) : base(name, sellIn, quality, basePrice)
        {
        }

        public override int GetValue()
        {
            return 0;
        }

        public override void Update()
        {            
        }
    }
}