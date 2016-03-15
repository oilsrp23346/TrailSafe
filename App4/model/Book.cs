using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Model
{
    public class Book
    {
        public string Topic { get; set; }
        public string Name { get; set; }
        public int Idcard { get; set; }
        public string WhistbandId { get; set; }
        public string pic { get; set; }
    }

    public class BooksManager
    {
        public static void GetBooks(string topic, ObservableCollection<Book> booksItems)
        {
            var allItems = getBooksItems();

            var filteredNewsItems = allItems.Where(p => p.Topic == topic).ToList();

            booksItems.Clear();

            filteredNewsItems.ForEach(p => booksItems.Add(p));
        }
        private static List<Book> getBooksItems()
        {
            var books = new List<Book>();

            books.Add(new Book { Topic = "Tourist", Idcard = 1, Name = "Aek", WhistbandId = "Futurum", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 2, Name = "Dong", WhistbandId = "Sequiter Que", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 3, Name = "Jo", WhistbandId = "Tempor", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 4, Name = "Pipe", WhistbandId = "Option", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 5, Name = "Sun", WhistbandId = "Accumsan", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 6, Name = "Graph", WhistbandId = "Legunt Xaepius", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 7, Name = "Boat", WhistbandId = "Eleifend", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 8, Name = "Pat", WhistbandId = "Vero Tation", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 9, Name = "Nut", WhistbandId = "Jack Tibbles", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 10, Name = "Oil", WhistbandId = "Tuffy Tibbles", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 11, Name = "Oat", WhistbandId = "Volupat", pic = "image/placeholder-sdk.png" });
            books.Add(new Book { Topic = "Tourist", Idcard = 12, Name = "Ice", WhistbandId = "Est Possim", pic = "image/placeholder-png.jpg" });
            books.Add(new Book { Topic = "Tourist", Idcard = 13, Name = "Nut", WhistbandId = "Magna", pic = "image/placeholder-sdk.png" });

            return books;
        }
    }
}
