using System;

public class NegativeGoal : Goal
{
    public NegativeGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {GetShortName()} ({GetDescription()}) -- bad habit, costs points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
    }
}
