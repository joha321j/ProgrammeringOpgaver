using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delegates;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        double delta = 0.00000001;
        Order order;

        [TestInitialize]
        public void Init()
        {
            order = new Order();
            order.AddProduct(new Product { Name = "Mælk", Value = 10.0 });
            order.AddProduct(new Product { Name = "Smør", Value = 15.0 });
            order.AddProduct(new Product { Name = "Pålæg", Value = 20.0 });
        }
        [TestMethod]
        public void TenPercent_Test()
        {
            Assert.AreEqual(4.5, Bonus.TenPercent(45.0), delta);
            Assert.AreEqual(40.0, Bonus.TenPercent(400.0), delta);
        }
        [TestMethod]
        public void FlatTwoIfAMountMoreThanFive_Test()
        {
            Assert.AreEqual(2.0, Bonus.FlatTwoIfAmountMoreThanFive(10.0), delta);
            Assert.AreEqual(0.0, Bonus.FlatTwoIfAmountMoreThanFive(4.0), delta);
        }
        [TestMethod]
        public void GetValueOfProducts_Test()
        {
            Assert.AreEqual(45.0, order.GetValueOfProducts(), delta);
        }
        [TestMethod]
        public void GetBonus_Test()
        {
            order.Bonus = Bonus.TenPercent;
            Assert.AreEqual(4.5, order.GetBonus(), delta);

            order.Bonus = Bonus.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(2.0, order.GetBonus(), delta);
        }
        [TestMethod]
        public void GetTotalPrice_Test()
        {
            order.Bonus = Bonus.TenPercent;
            Assert.AreEqual(40.5, order.GetTotalPrice(), delta);

            order.Bonus = Bonus.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(43.0, order.GetTotalPrice(), delta);
        }
    }

}
