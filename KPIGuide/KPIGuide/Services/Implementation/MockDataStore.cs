using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPIGuide.Models;
using KPIGuide.Services.Interfaces;

namespace KPIGuide.Services.Implementation
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public bool AddItem(Item item)
        {
            items.Add(item);
            return true;
        }

        public bool UpdateItem(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            return true;
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return true;
        }

        public Item GetItem(string id)
        {
            return items.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Item> GetItems(bool forceRefresh = false)
        {
            return items;
        }
    }
}