using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        bool breatheIn = true;
        while (DateTime.Now < end)
        {
            Console.WriteLine();
            if (breatheIn)
            {
                Console.Write("Breathe in... ");
                GrowBreath(6, true);
            }
            else
            {
                Console.Write("Breathe out... ");
                GrowBreath(6, false);
            }
            breatheIn = !breatheIn;
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }

    private void GrowBreath(int count, bool growing)
    {
        for (int i = 1; i <= count; i++)
        {
            int shown = growing ? i : count - i + 1;
            Console.Write(new string('o', shown));
            double fraction = (double)i / count;
            int delay = (int)(150 + 500 * fraction);
            Thread.Sleep(delay);
            Console.Write(new string('\b', shown));
            Console.Write(new string(' ', shown));
            Console.Write(new string('\b', shown));
        }
    }
}
