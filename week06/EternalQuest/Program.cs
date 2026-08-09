using System;

// Exceeding requirements:
// 1. Gamification with leveling: every 1000 points raises the user's level and unlocks
//    a new title (Humble Beginner -> Steady Squire -> Valiant Knight -> Legendary Ninja
//    Unicorn), shown above the menu (GoalManager.GetLevel / GetTitle).
// 2. Added a Negative Goal type (NegativeGoal.cs) for bad habits that SUBTRACT points
//    each time they are recorded.
// 3. Added a Progress Goal type (ProgressGoal.cs) that earns points for each step of
//    progress toward a large goal and reports a percentage complete.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
