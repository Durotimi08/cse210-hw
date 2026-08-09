using System;
using System.Collections.Generic;
using System.IO;

public class ActivityLog
{
    private Dictionary<string, int> _counts;
    private string _filePath;

    public ActivityLog(string filePath)
    {
        _filePath = filePath;
        _counts = new Dictionary<string, int>();
        Load();
    }

    public void Record(string activityName)
    {
        if (_counts.ContainsKey(activityName))
        {
            _counts[activityName]++;
        }
        else
        {
            _counts[activityName] = 1;
        }
        Save();
    }

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("Activity Log (all-time):");
        if (_counts.Count == 0)
        {
            Console.WriteLine("  No activities completed yet.");
            return;
        }
        foreach (KeyValuePair<string, int> entry in _counts)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
        }
    }

    private void Load()
    {
        if (!File.Exists(_filePath))
        {
            return;
        }
        foreach (string line in File.ReadAllLines(_filePath))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 2 && int.TryParse(parts[1], out int count))
            {
                _counts[parts[0]] = count;
            }
        }
    }

    private void Save()
    {
        List<string> lines = new List<string>();
        foreach (KeyValuePair<string, int> entry in _counts)
        {
            lines.Add($"{entry.Key}|{entry.Value}");
        }
        File.WriteAllLines(_filePath, lines);
    }
}
