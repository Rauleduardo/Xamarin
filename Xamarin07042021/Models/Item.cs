using System;
using SQLite;

namespace Xamarin07042021.Models
{
    public class Item
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }


    }
}