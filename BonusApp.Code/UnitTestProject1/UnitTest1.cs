using System;
using BonusApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Order _order;

        [TestInitialize]
        public void InitializeTest()
        {
            _order = new Order();
            _order.AddProduct(new Product
            {
                Name = "Mælk",
                Value = 10.0
            });
            _order.AddProduct(new Product
            {
                Name = "Smør",
                Value = 15.0
            });
            _order.AddProduct(new Product
            {
                Name = "Pålæg",
                Value = 20.0
            });
        }
        [TestMethod]
        public void TenPercent_Test()
        {
            Assert.AreEqual(4.5, Bonuses.TenPercent(45.0));
            Assert.AreEqual(40.0, Bonuses.TenPercent(400.0));
        }
        [TestMethod]
        public void FlatTwoIfAMountMoreThanFive_Test()
        {
            Assert.AreEqual(2.0, Bonuses.FlatTwoIfAmountMoreThanFive(10.0));
            Assert.AreEqual(0.0, Bonuses.FlatTwoIfAmountMoreThanFive(4.0));
        }
        [TestMethod]
        public void GetValueOfProducts_Test()
        {
            Assert.AreEqual(45.0, _order.GetValueOfProducts());
        }
        [TestMethod]
        public void GetBonus_Test()
        {
            _order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(4.5, _order.GetBonus());

            _order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(2.0, _order.GetBonus());
        }
        [TestMethod]
        public void GetTotalPrice_Test()
        {
            _order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(40.5, _order.GetTotalPrice());

            _order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(43.0, _order.GetTotalPrice());
        }

        [TestMethod]
        public void GetBonusAnonymous_Test()
        {
            _order.Bonus = delegate(double amount) { return amount / 10.0;}; // <- Change to anonymous delegate
            Assert.AreEqual(4.5, _order.GetBonus());

            _order.Bonus = delegate(double amount) { return amount > 5 ? 2.0 : 0.0; }; // <- Change to anonymous delegate
            Assert.AreEqual(2.0, _order.GetBonus());
        }

        [TestMethod]
        public void GetBonusLambda_Test()
        {
            _order.Bonus = x => x / 10.0; // <- Change to lambda expression
            Assert.AreEqual(4.5, _order.GetBonus());

            _order.Bonus = x => x > 5 ? 2.0 : 0.0; // <- Change to lambda expression
            Assert.AreEqual(2.0, _order.GetBonus());
        }

        [TestMethod]
        public void GetBonusByLambdaParameter_Test()
        {
            // Use TenPercent lambda expresssion as parameter to GetBonus
            Assert.AreEqual(4.5, _order.GetBonus(x => x / 10.0));

            // Use FlatTwoIfAmountMoreThanFive lambda expresssion as parameter to GetBonus
            Assert.AreEqual(2.0, _order.GetBonus(x => x > 5.0 ? 2.0 : 0.0));
        }

        [TestMethod]
        public void GetTotalPriceByLambdaParameter_Test()
        {
            Assert.AreEqual(40.5, _order.GetTotalPrice(x => x / 10.0));

            Assert.AreEqual(43.0, _order.GetTotalPrice(x => x > 5.0 ? 2.0 : 0.0));
        }



    }

}
