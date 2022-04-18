using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Testlet_Info;

namespace Testlet_Test
{
    [TestClass]
    public class Testlet_Test
    {
        #region Data Initialization

        private List<Item> GetTenTestlets()
        {
            return new List<Item>
            {
                new Item() { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "4", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "5", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "7", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "8", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "9", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "10", ItemType = ItemTypeEnum.Operational }
            };
        }

        private List<Item> GetLessThan10Testlets()
        {
            return new List<Item>
            {
                new Item() { ItemId = "1", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "4", ItemType = ItemTypeEnum.Operational }
            };
        }
        private List<Item> GetMoreThan10Testlets()
        {
            return new List<Item>
            {
                new Item() { ItemId = "1", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "4", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "5", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "6", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "7", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "9", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "10", ItemType = ItemTypeEnum.Pretest },
                new Item() { ItemId = "11", ItemType = ItemTypeEnum.Operational },
                new Item() { ItemId = "12", ItemType = ItemTypeEnum.Operational },
            };
        }

        #endregion

        #region Assert

        //less than 10 items
        [TestMethod]
        public void LessThan10Items()
        {           
            var lessItems = new Testlet("1", GetLessThan10Testlets());
            var exception = Assert.ThrowsException<Exception>(() => lessItems.Randomize());
            Assert.AreEqual("Testlet items cannot be less than 10!", exception.Message);
        }


        //greater than 10 items
        [TestMethod]
        public void MoreThan10Items()
        {
            //Assert more items
            var moreItems = new Testlet("1", GetMoreThan10Testlets());
            var exception = Assert.ThrowsException<Exception>(() => moreItems.Randomize());
            Assert.AreEqual("Testlet items cannot be more than 10!", exception.Message);
        }

        //Null Items
        [TestMethod]
        public void NullCheck()
        {
            //Assert more items
            var nullItems = new Testlet("1", null);
            var exception = Assert.ThrowsException<ArgumentNullException>(() => nullItems.Randomize());
            Assert.IsTrue(exception.Message.Contains("Testlet items cannot be empty!"));
        }

        //First two are pretest items
        [TestMethod]
        public void CheckIf_First2Are_PreTestItems()
        {

            Testlet tl = new Testlet("1", GetTenTestlets());

            // is first item pretest
            Assert.IsTrue(tl.Randomize()[0].ItemType == ItemTypeEnum.Pretest, "First Item is not Pretest!");

            // is second item pretest
            Assert.IsTrue(tl.Randomize()[1].ItemType == ItemTypeEnum.Pretest, "Second Item is not Pretest!");

        }

        //List is randamized
        [TestMethod]
        public void IsRandamized()
        {

            List<Item> testlets = GetTenTestlets();

            Testlet tl = new Testlet("1", testlets);

            CollectionAssert.AreNotEqual(tl.Randomize(), testlets, "Records in Expected set are not Randomized!");

        }

        //all items are returned
        [TestMethod]
        public void IsCountMatches()
        {

            List<Item> testlets = GetTenTestlets();

            Testlet tl = new Testlet("1", GetTenTestlets());

            Assert.AreEqual(tl.Randomize().Count, testlets.Count, "All Items are not returned!");

        }

        //All unique items are returned
        [TestMethod]
        public void IsAllItemsUnique()
        {
            Testlet tl = new Testlet("1", GetTenTestlets());

            CollectionAssert.AllItemsAreUnique(tl.Randomize(), "Duplicate Items found!");

        }

        #endregion

    }
}
