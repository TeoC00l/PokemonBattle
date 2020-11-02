//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Stats
{
    private BaseStats baseStats;

    private int hp;
    private int attack;
    private int defense;
    private int speed;
    private int special;
    
    private int currentHP;
    private int currentAttack;
    private int currentDefense;
    private int currentSpeed;
    private int currentSpecial;

    public Stats(BaseStats baseStats, int level)
    {
        this.baseStats = baseStats;
        SetStats(level);
    }

    public void ResetStats()
    {
        currentHP = hp;
        currentAttack = attack;
        currentDefense = defense;
        currentSpeed = speed;
        currentSpecial = special;
    }

    public void SetStats(int level)
    {
        hp = Calculations.CalculateHP(baseStats.baseHP, level);
        attack = Calculations.CalculateStat(baseStats.baseAttack, level);
        defense = Calculations.CalculateStat(baseStats.baseDefense, level);
        speed = Calculations.CalculateStat(baseStats.baseSpeed, level);
        speed = Calculations.CalculateStat(baseStats.baseSpecial, level);

        ResetStats();
    }
}
