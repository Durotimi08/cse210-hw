using System;

public class ProgressGoal : Goal
{
    private int _current;
    private int _target;

    public ProgressGoal(string shortName, string description, int points, int target, int current = 0)
        : base(shortName, description, points)
    {
        _target = target;
        _current = current;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }
        _current++;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _current >= _target;
    }

    public override string GetDetailsString()
    {
        string mark = IsComplete() ? "X" : " ";
        int percent = _target == 0 ? 0 : (_current * 100) / _target;
        return $"[{mark}] {GetShortName()} ({GetDescription()}) -- Progress: {_current}/{_target} ({percent}%)";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_target},{_current}";
    }
}
