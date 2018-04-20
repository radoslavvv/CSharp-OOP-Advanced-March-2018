public interface IItem
{
    string Name { get; }

    long StrengthBonus { get; }

    long AgilityBonus { get; }

    long IntelligenceBonus { get; }

    long DamageBonus { get; }

    long HitPointsBonus { get; }
}