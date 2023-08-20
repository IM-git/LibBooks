using System;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibBooks
{
    class Program
    {
        private const string Path = @"./author_books.json";
        static List<string> books = new List<string>(); // the list of the books
        static List<string> authors = new List<string>();   // the list of the authors

        static void Main()
        {
            Program library = new Program(); // creating instance of the Program class

            while (true) // the loop for working with "library"
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Read List");
                Console.WriteLine("2. Write Book");
                Console.WriteLine("3. Write Author");
                Console.WriteLine("4. Save from Json");
                Console.WriteLine("5. Load from Json");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.ReadList();
                        break;

                    case "2":
                        string book = library.WriteBook();
                        books.Add(book); // add the book to the list
                        break;

                    case "3":
                        string author = library.WriteAuthor();
                        authors.Add(author); // add the author to the list
                        break;

                    case "4":
                        library.SaveToJson();
                        break;

                    case "5":
                        library.LoadFromJson();
                        break;

                    case "6":
                        Environment.Exit(0); // Exit to program
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void ReadList()
        {
            Console.WriteLine("Books:");
            Console.WriteLine(string.Join(", ", books)); // write books

            Console.WriteLine("Authors:");
            Console.WriteLine(string.Join(", ", authors)); // write authors
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

        public void SaveToJson()
        {
            // create object which will be serialized to JSON
            var data = new
            {
                Authors = authors,
                Books = books
            };

            // serialize the data in JSON and write it to file
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(Path, json);

            Console.WriteLine("Data saved to JSON.");
        }

        public void LoadFromJson()
        {
            if (File.Exists(Path))
            {
                // read a JSON from the file and deserialize it into an object
                string json = File.ReadAllText(Path);
                var data = JsonSerializer.Deserialize<dynamic>(json);

                // update book's and author's lists
                authors = new List<string>(data.Authors.ToObject<List<string>>());
                books = new List<string>(data.Books.ToObject<List<string>>());

                Console.WriteLine("Data loaded from JSON.");
            }
            else
            {
                Console.WriteLine("JSON file not found.");
            }

        }
    }
}