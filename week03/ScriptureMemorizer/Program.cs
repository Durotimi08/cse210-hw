using System;
using System.Collections.Generic;
using System.IO;

// Exceeding requirements:
// 1. The program works with a library of scriptures rather than a single one, and
//    picks one at random to present to the user each time it runs.
// 2. The scripture library is loaded from an external file (scriptures.txt) so new
//    scriptures can be added without changing the code.
// 3. The stretch challenge is implemented: only words that are NOT already hidden
//    are chosen when hiding, so every prompt reveals real progress.
// 4. The program stops prompting and ends automatically once every word is hidden.

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = LoadLibrary();
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Great job!");
                break;
            }

            Console.Write("Press the enter key to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    // Loads scriptures from the file, or falls back to a built-in scripture.
    static List<Scripture> LoadLibrary()
    {
        List<Scripture> library = new List<Scripture>();
        string path = "scriptures.txt";

        if (File.Exists(path))
        {
            foreach (string line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                string book = parts[0];
                int chapter = int.Parse(parts[1]);

                if (parts.Length == 5)
                {
                    Reference reference = new Reference(book, chapter, int.Parse(parts[2]), int.Parse(parts[3]));
                    library.Add(new Scripture(reference, parts[4]));
                }
                else
                {
                    Reference reference = new Reference(book, chapter, int.Parse(parts[2]));
                    library.Add(new Scripture(reference, parts[3]));
                }
            }
        }

        if (library.Count == 0)
        {
            Reference reference = new Reference("John", 3, 16);
            library.Add(new Scripture(reference, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"));
        }

        return library;
    }
}
