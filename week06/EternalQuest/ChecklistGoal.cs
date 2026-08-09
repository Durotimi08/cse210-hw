using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            return GetPoints() + _bonus;
        }
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string mark = IsComplete() ? "X" : " ";
        return $"[{mark}] {GetShortName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_target},{_bonus},{_amountCompleted}";
    }
}
