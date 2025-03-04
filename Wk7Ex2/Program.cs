using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Wk7Ex2
{
    // Book class initializing properties
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFileName = "book.json"; // JSON file to store the serialized book data

            // Create a Book object 
            Book myBook = new Book
            {
                Title = "1984",
                Author = "George Orwell",
                Year = 1949
            };

            // Serialize the Book object to a JSON file
            SerializeToJson(jsonFileName, myBook);
            Console.WriteLine($"Book serialized to {jsonFileName}");

            // Deserialize the JSON file back into a Book object
            Book deserializedBook = DeserializeFromJson(jsonFileName);
            if (deserializedBook != null)
            {
                // Display the details of the deserialized book
                Console.WriteLine("\nDeserialized Book Details:");
                Console.WriteLine($"Title: {deserializedBook.Title}");
                Console.WriteLine($"Author: {deserializedBook.Author}");
                Console.WriteLine($"Year: {deserializedBook.Year}");
            }
            Console.ReadLine();
        }

        // Method to serialize a Book object to a JSON file
        static void SerializeToJson(string fileName, Book book)
        {
            // Convert the Book object to JSON format with indentation for readability
            string json = JsonSerializer.Serialize(book);

            // Write the JSON content to the specified file
            File.WriteAllText(fileName, json);
        }

        // Method to deserialize a JSON file back into a Book object
        static Book DeserializeFromJson(string fileName)
        {
            // Check if the file exists
            if (!File.Exists(fileName))
            {
                Console.WriteLine("JSON file not found.");
                return null;
            }

            // Read the JSON content from the file
            string json = File.ReadAllText(fileName);

            // Convert the JSON string back into a Book object and return it
            return JsonSerializer.Deserialize<Book>(json);
        }
    }
}
