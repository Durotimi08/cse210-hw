using System;
using System.Collections.Generic;

public class RandomBag
{
    private List<string> _items;
    private List<string> _remaining;
    private Random _random;

    public RandomBag(List<string> items)
    {
        _items = new List<string>(items);
        _remaining = new List<string>(items);
        _random = new Random();
    }

    public string Draw()
    {
        if (_remaining.Count == 0)
        {
            _remaining = new List<string>(_items);
        }
        int index = _random.Next(_remaining.Count);
        string choice = _remaining[index];
        _remaining.RemoveAt(index);
        return choice;
    }
}
