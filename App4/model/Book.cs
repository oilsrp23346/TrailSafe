using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ename { get; set; }
        public string Relation { get; set; }
        public string Tel { get; set; }
        public string Wid { get; set; }
        public string pic { get; set; }
    }

    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();

            books.Add(new Book { Id = 1, Name = "Aek", Ename = "Futurum", pic = "./image/1.jpg" });
           /* books.Add(new Book { Id = 2, Name = "Dong", Ename = "Sequiter Que", pic = "image/2.jpg" });
            books.Add(new Book { Id = 3, Name = "Jo", Ename = "Tempor", pic = "image/3.jpg" });
            books.Add(new Book { Id = 4, Name = "Pipe", Ename = "Option", pic = "image/4.jpg" });
            books.Add(new Book { Id = 5, Name = "Sun", Ename = "Accumsan", pic = "image/5.jpg" });
            books.Add(new Book { Id = 6, Name = "Graph", Ename = "Legunt Xaepius", pic = "image/6.jpg" });
            books.Add(new Book { Id = 7, Name = "Boat", Ename = "Eleifend", pic = "image/7.jpg" });
            books.Add(new Book { Id = 8, Name = "Pat", Ename = "Vero Tation", pic = "image/8.jpg" });
            books.Add(new Book { Id = 9, Name = "Nut", Ename = "Jack Tibbles", pic = "image/9.jpg" });
            books.Add(new Book { Id = 10, Name = "Oil", Ename = "Tuffy Tibbles", pic = "image/10.jpg" });
            books.Add(new Book { Id = 11, Name = "Oat", Ename = "Volupat", pic = "image/11.jpg" });
            books.Add(new Book { Id = 12, Name = "Ice", Ename = "Est Possim", pic = "image/12.jpg" });
            books.Add(new Book { Id = 13, Name = "Nut", Ename = "Magna", pic = "image/13.jpg" });
            books.Remove(new Book { Id = 1, Name = "Aek", Ename = "Futurum", pic = "image/1.jpg" });*/
            return books;
        }
    }
}
