using System;
using System.Collections.Generic;
using System.Linq;

namespace Testlet_Info
{
    public class Testlet
    {
        public string TestletId; 
        private List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
        public List<Item> Randomize()
        {

            if (Items == null)
                throw new ArgumentNullException("Items", "Testlet items cannot be empty!");

            if (Items.Count > 10)
                throw new Exception("Testlet items cannot be more than 10!");

            if (Items.Count < 10)
                throw new Exception("Testlet items cannot be less than 10!");

            Random rand = new Random();

            var pretestItems = Items.Where(t => t.ItemType == ItemTypeEnum.Pretest).OrderBy(o => rand.Next()).Take(2).ToList();

            var remainigItems= Items.Except(pretestItems).OrderBy(o => rand.Next()).ToList();

            return pretestItems.Concat(remainigItems).ToList();

        }
    }
    public class Item
    {
        public string ItemId; public ItemTypeEnum ItemType;

    }
    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }

}
