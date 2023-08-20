using System;
using System.Xml.Linq;

namespace LibBooks
{
    class Program
    {

        public static void Main()
        {
            Program library = new Program();  // Creating a instance of the LibBooks class

            string nameBook = library.WriteBook();    // Write a book name
            string nameAuthor = library.WriteAuthor();    // Write a author name

            library.ReadList(nameBook, nameAuthor); // Read the books and author names
            Console.ReadLine();
        }

        public void ReadList(string name, string author)
        {

            Console.WriteLine(name);
            Console.WriteLine(author);
        }

        public string WriteBook()
        {
            Console.WriteLine("Enter the book's name: ");
            string book = Console.ReadLine();
            return book;
        }
        public string WriteAuthor()
        {
            Console.WriteLine("Enter the author's name: ");
            string book = Console.ReadLine();
            return book;
        }
    }
}