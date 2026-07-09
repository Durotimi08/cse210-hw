using System;
using System.Collections.Generic;

public class Entry
{
    public string _date = "";
    public string _time = "";
    public string _promptText = "";
    public string _entryText = "";
    public string _mood = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date} {_time} | Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine();
    }

    public string ToCsvLine()
    {
        return $"{Escape(_date)},{Escape(_time)},{Escape(_mood)},{Escape(_promptText)},{Escape(_entryText)}";
    }

    public void LoadFromFields(List<string> fields)
    {
        _date = fields[0];
        _time = fields[1];
        _mood = fields[2];
        _promptText = fields[3];
        _entryText = fields[4];
    }

    private string Escape(string value)
    {
        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
        {
            string doubled = value.Replace("\"", "\"\"");
            return $"\"{doubled}\"";
        }
        return value;
    }
}
