using System;

// Exceeding requirements:
// 1. Added a fourth activity: the Gratitude Activity (GratitudeActivity.cs), which
//    invites the user to name and savor one blessing at a time.
// 2. Keeps a log of how many times each activity has been performed (ActivityLog.cs),
//    shown from the menu with option 6.
// 3. No random prompt or question repeats until every prompt in that list has been
//    used at least once (RandomBag.cs draws without replacement, then reshuffles).
// 4. The log is saved to and loaded from a file (mindfulness_log.txt), so activity
//    counts persist across runs.
// 5. More meaningful breathing animation: the "o" text grows out quickly at first and
//    slows as the breath nears its end (BreathingActivity.GrowBreath).

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog("mindfulness_log.txt");

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");
            Console.WriteLine("  5. View activity log");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    log.Record(breathing.GetName());
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    log.Record(reflection.GetName());
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    log.Record(listing.GetName());
                    break;
                case "4":
                    GratitudeActivity gratitude = new GratitudeActivity();
                    gratitude.Run();
                    log.Record(gratitude.GetName());
                    break;
                case "5":
                    Console.Clear();
                    log.Display();
                    Console.WriteLine();
                    Console.Write("Press enter to return to the menu.");
                    Console.ReadLine();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    Console.Write("Press enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
