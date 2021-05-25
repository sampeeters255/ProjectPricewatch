using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pricewatch_DAL;
using System.Collections.Generic;

namespace Pricewatch_UnitTest
{
    [TestClass]
    public class PricewatchTests
    {
        [TestMethod]
        public void ProductWinkelId_ValueIsGroterDan0_ProductWinkelIdIsValue()
        {
            //arrange
            ProductWinkel productWinkel = new ProductWinkel();
            productWinkel.prijs = 5;
            productWinkel.productId = 5;
            productWinkel.winkelId = 2;


            //act
            productWinkel.productWinkelId = 2;

            //assert
            Assert.IsTrue(productWinkel.IsGeldig());                
            
        }
        [TestMethod]
        public void ProductOphalenViaSubCategorie_ValueIsGroterDan0_()
        {
            //arrange
            
            List<Product> products = new List<Product>();


            //act
            products = DatabaseOperations.ProductOphalenViaSubCategorie(4);

            //assert
            Assert.AreEqual(products.Count,3);

        }

    }
}
