using System;
using System.Collections.Generic;
using GildedRose;
using GildedRose.ViewBoundary;

namespace GildedRoseUI
{ 
    public class ConsoleView : ShopOutputBoundary
    {
        public void DisplayMenu()
        {
            Console.WriteLine("-------Menu--------");
            Console.WriteLine("1. Voir inventaire");
            Console.WriteLine("2. Voir solde magasin");
            Console.WriteLine("3. Mettre à jour inventaire");
            Console.WriteLine("4. Acheter item");
            Console.WriteLine("5. Faire une enchère sur un item");
            Console.WriteLine("6. Quitter");
            Console.WriteLine("-------------------");
        }

        public void DisplayInventory(IList<ItemResponse> itemsResponse)
        {
    
            Console.WriteLine("Inventaire :");
            var i = 1;
            foreach(var itemResponse in itemsResponse)
            {
                Console.WriteLine(i+ ". Nom : "+itemResponse.name+", Vendre dans : "+itemResponse.sellIn+", Qualité : "+itemResponse.quality+", Prix : "+itemResponse.value);
                i++;
            }
        }

        public void DisplayBalance(int Balance)
        {
            Console.WriteLine("Le solde du magasin est de "+ Balance);
        }

        public void DisplayInventoryUpdate()
        {
            Console.WriteLine("L'inventaire a été mis à jour");
        }

        public void DisplaySellItem()
        {
            Console.WriteLine("Quel article souhaitez-vous acheter ?");
        }

        public void DisplayBidItem(){
            Console.WriteLine("Sur quel article souhaitez-vous faire une enchère ?");
        }

        public void DisplayResultBidItem(decimal resultBidItem){
            Console.WriteLine("L'enchère gagnante est "+resultBidItem);
        }
    }
}