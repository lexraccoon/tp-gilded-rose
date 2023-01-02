using System;
using System.Collections.Generic;
using GildedRose.Items;
using GildedRose.ItemsRepository;
using GildedRose.ViewBoundary;
using GildedRose.ShopBoundary;

namespace GildedRose
{
    public class ShopInteractor : ShopInputBoundary
    {
        private ItemsGateway repository;
        private int balance;
        private ShopOutputBoundary output;
        public ShopInteractor(ItemsGateway repository, ShopOutputBoundary output)
        {
            this.repository = repository;
            this.output = output;
        }

        public int Balance => this.balance;
        public ItemsGateway Repository => this.repository;
        public IList<Item> Inventory => this.repository.GetInventory();

        public void DisplayMenu(){
            this.output.DisplayMenu();
        }

        public void UpdateInventory()
        {
            foreach(Item item in Inventory)
                item.Update();
            this.repository.SaveInventory(Inventory);
            this.output.DisplayInventoryUpdate();
        }

        public void DisplayInventory(){
            IList<ItemResponse> itemsResponse = new List<ItemResponse>();
            foreach(Item i in Inventory)
                itemsResponse.Add(new ItemResponse{
                   name = i.name,
                   sellIn = i.sellIn,
                   quality = i.quality,
                   value = i.GetValue()
                });

            this.output.DisplayInventory(itemsResponse);
        }

        public void DisplayBalance(){
            this.output.DisplayBalance(this.balance);
        }

        public void DisplaySellItem(){
            this.output.DisplaySellItem();
        }

        public void SendSmsNotification(Item item){
            SmsHelper smsHelper = new SmsHelper();
            smsHelper.SendSms("+33785073429", "L'item suivant a été vendu "+item.name+", "+item.quality+", "+item.sellIn+", "+item.GetValue());
        }

        public void SellItem(SellItemRequest request)
        {
            var item = this.repository.FindItem(request.Type, request.Quality);
            if(item != null){
                Inventory.Remove(item);
                this.repository.SaveInventory(Inventory);
                this.balance += item.GetValue();
                SendSmsNotification(item);
            }
        }

        public void DisplayBidItem(){
            this.output.DisplayBidItem();
        }

        public decimal BidItem(SellItemRequest request){
            var item = this.repository.FindItem(request.Type, request.Quality);
            decimal montantEnchere = item.GetValue();
            for(int nbrEnchere = 1; nbrEnchere <= 3; nbrEnchere++){
                montantEnchere *= 1.1m;
            }
            return montantEnchere;
        }

        public void DisplayResultBidItem(decimal resultBidItem){
            this.output.DisplayResultBidItem(resultBidItem);
        }
    }
}