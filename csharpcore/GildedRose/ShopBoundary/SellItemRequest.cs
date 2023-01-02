namespace GildedRose.ShopBoundary
{
    public class SellItemRequest
    {
        public string Type{get; private set;}
        public int Quality{get; private set;}

        public SellItemRequest(string type, int quality)
        {
            this.Type = type;
            this.Quality = quality;
        }
    }
}