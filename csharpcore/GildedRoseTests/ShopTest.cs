using GildedRose;
using GildedRoseUI;
using GildedRose.ItemsRepository;
using GildedRose.ShopBoundary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestClass]
    public class ShopTest
    {
        public ShopInteractor shop;
        public ConsoleView consoleView;
        public ItemsGateway repository;    
        
        [TestInitialize]
        public void Setup()
        {
            this.repository = new InMemoryItemsRepository();
            this.consoleView = new ConsoleView();
            this.shop = new ShopInteractor(this.repository, this.consoleView);
        }
        
        [TestMethod]
        public void Should_UpdateItemProperties()
        {
            this.shop.UpdateInventory();
           
            Assert.AreEqual(9, this.repository.GetInventory()[0].sellIn);
            Assert.AreEqual(8, this.repository.GetInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration()
        {
            this.shop.UpdateInventory();
            
            Assert.AreEqual(6, this.repository.GetInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality()
        {
            this.shop.UpdateInventory();
            
            Assert.AreEqual(0, this.repository.GetInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(5, this.repository.GetInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityPastFifty()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(50, this.repository.GetInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(5, this.repository.GetInventory()[5].sellIn);
            Assert.AreEqual(80, this.repository.GetInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(11, this.repository.GetInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(12, this.repository.GetInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoFiveDaysBefore()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(13, this.repository.GetInventory()[8].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityToZeroAfterEvent()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(0, this.repository.GetInventory()[9].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAsNormalItems()
        {
            this.shop.UpdateInventory();

            Assert.AreEqual(8, this.repository.GetInventory()[10].quality);
        }

        [TestMethod]
        public void Should_SellItem()
        {
            
            this.shop.SellItem(new SellItemRequest("Conjured", 10));
            Assert.AreEqual(10, this.repository.GetInventory().Count);
            Assert.AreEqual(766, this.shop.Balance);
        }

    }
    
}