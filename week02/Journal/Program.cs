// Exceeding requirements: saves and loads as a real .csv file with proper
// handling of commas and quotation marks so it opens cleanly in Excel.
// Also stores extra info on each entry: the time of day and the user's mood.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteEntry(journal, promptGenerator);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded.");
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Journal saved.");
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Please choose a valid option.");
            }

            Console.WriteLine();
        }
    }

    static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        Entry entry = new Entry();
        entry._promptText = promptGenerator.GetRandomPrompt();

        Console.WriteLine(entry._promptText);
        Console.Write("> ");
        entry._entryText = Console.ReadLine();

        Console.Write("In one word, how are you feeling? ");
        entry._mood = Console.ReadLine();

        DateTime now = DateTime.Now;
        entry._date = now.ToShortDateString();
        entry._time = now.ToShortTimeString();

        journal.AddEntry(entry);
    }
}