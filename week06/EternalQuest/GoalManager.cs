using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {GetLevel()} -- {GetTitle()}");
    }

    private int GetLevel()
    {
        return _score / 1000 + 1;
    }

    private string GetTitle()
    {
        int level = GetLevel();
        if (level >= 10)
        {
            return "Legendary Ninja Unicorn";
        }
        if (level >= 5)
        {
            return "Valiant Knight";
        }
        if (level >= 3)
        {
            return "Steady Squire";
        }
        return "Humble Beginner";
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        Console.WriteLine("  5. Progress Goal (work toward a big goal)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            case "5":
                Console.Write("How many steps until this large goal is complete? ");
                int steps = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, description, points, steps));
                break;
            default:
                Console.WriteLine("That was not a valid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }
        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();
        Console.Write("Enter the number of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That was not a valid goal.");
            return;
        }
        int earned = _goals[index].RecordEvent();
        _score += earned;
        if (earned >= 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
        }
        else
        {
            Console.WriteLine($"Ouch! You have lost {-earned} points.");
        }
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            _goals.Add(ParseGoal(lines[i]));
        }
    }

    private Goal ParseGoal(string line)
    {
        string[] typeAndData = line.Split(':', 2);
        string type = typeAndData[0];
        string[] parts = typeAndData[1].Split(',');

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
            case "EternalGoal":
                return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
            case "NegativeGoal":
                return new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
            case "ProgressGoal":
                return new ProgressGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
            default:
                return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
        }
    }
}
