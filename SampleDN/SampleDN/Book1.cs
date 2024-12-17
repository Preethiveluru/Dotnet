//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SampleDN
//{
//    abstract class Book1
//    {
//        public string Title { get; set; }
//        public string Author { get; set; }

//        public Book1(string title, string author)
//        {
//            Title = title; Author = author;
//        }

//        public abstract void Showbookinfo();
//        public  virtual  void Read()
//        {
//            Console.WriteLine($"Reading {Title} by {Author}");
//        }
//        public void Read(int pages)
//        {
//            Console.WriteLine($"Reading {pages} pages of {Title} by {Author}...");
//        }

//        public void Read(string format)
//        {
//            Console.WriteLine($"Reading {Title} by {Author} in {format} format...");
//        }

//        public void Read(int pages, string format)
//        {
//            Console.WriteLine($"Reading {pages} pages of {Title} by {Author} in {format} format...");
//        }


//    }

//    class FrictionalBook : Book1
//    {
//        public string Genre { get; set; }

//        public FrictionalBook(string title, string author, string genre)
//            : base(title, author)
//        {
//            Genre = genre;
//        }

//        public override void Showbookinfo()
//        {
//            Console.WriteLine($"Fiction Book: {Title} by {Author}, Genre: {Genre}");
//        }
//    }
//    class NonFictionalBook : Book1
//    {
//        public string Subject { get; set; }

//        public NonFictionalBook(string title, string author, string subject) : base(title, author)
//        {
//            Subject = subject;
//        }

//        public override void Showbookinfo()
//        {
//            Console.WriteLine($"Non-Fiction Book: {Title} by {Author}, Subject: {Subject}");
//        }


//    }
//}
