using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoBookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("LibraryDB");
            var coll = db.GetCollection<Books>("Books");


            Books book = new Books
            {
                BookTitle = "MongoDB Basics",
                ISBN = "8767687689898yu",
                Author = "Tanya",
                Category = "NoSQL DBMS"
            };

            coll.InsertOne(book);

            var booklist = coll.Find(b => b.BookTitle != null).ToListAsync().Result;

            foreach (var books in booklist)
            {
                Console.WriteLine(books.BookTitle);

            }
            Console.ReadKey();
        }
    }
    public class Books
    {
        public ObjectId Id { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string ISBN { get; set; }
    }
}
