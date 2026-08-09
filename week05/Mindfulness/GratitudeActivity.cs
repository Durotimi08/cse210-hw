using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private RandomBag _prompts;

    public GratitudeActivity()
        : base("Gratitude Activity", "This activity will help you feel more grateful by inviting you to name a blessing and pause to appreciate it deeply, one at a time.")
    {
        _prompts = new RandomBag(new List<string>
        {
            "Name something in nature you are grateful for.",
            "Name a person who made your day better.",
            "Name a small comfort you often overlook.",
            "Name an ability or talent you are thankful to have.",
            "Name a hard experience that made you stronger.",
            "Name something about your home you appreciate."
        });
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            Console.WriteLine();
            Console.WriteLine(_prompts.Draw());
            Console.Write("> ");
            Console.ReadLine();
            Console.Write("Sit with that feeling of gratitude ");
            ShowSpinner(5);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}
