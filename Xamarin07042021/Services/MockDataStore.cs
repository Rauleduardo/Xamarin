using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Xamarin07042021.Models;

namespace Xamarin07042021.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            /* items = new List<Item>()
             {
                 new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                 new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
             };*/
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            //3- creamos el bloque de conexion.
            using (SQLiteConnection connection = new SQLiteConnection(App.rutaDB))
            {

                connection.Insert(item);
            };

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.rutaDB))
            {
                return await Task.FromResult(connection.Table<Item>().FirstOrDefault(s => s.Id == id));
            };

        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {

            using (SQLiteConnection connection = new SQLiteConnection(App.rutaDB))
            {
                return await Task.FromResult(connection.Table<Item>().ToList());
            };
        }
    }
}