//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Stats
{
    private BaseStats baseStats;

    private int hp;
    private int attack;
    private int defense;
    private int speed;
    private int special;
    
    public int CurrentHP{ get; private set; }
    public int CurrentAttack{ get; private set; }
    public int CurrentDefense{ get; private set; }
    public int CurrentSpeed{ get; private set; }
    public int CurrentSpecial{ get; private set; }

    public Stats(BaseStats baseStats, int level)
    {
        this.baseStats = baseStats;
        SetStats(level);
    }

    public void ResetStats()
    {
        CurrentHP = hp;
        CurrentAttack = attack;
        CurrentDefense = defense;
        CurrentSpeed = speed;
        CurrentSpecial = special;
    }

    public void SetStats(int level)
    {
        hp = Calculations.CalculateHP(baseStats.baseHP, level);
        attack = Calculations.CalculateStat(baseStats.baseAttack, level);
        defense = Calculations.CalculateStat(baseStats.baseDefense, level);
        speed = Calculations.CalculateStat(baseStats.baseSpeed, level);
        special = Calculations.CalculateStat(baseStats.baseSpecial, level);

        ResetStats();
    }
}
