//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Stats
{
    public PokemonData Data { get; private set; }

    private int hp;
    private int attack;
    private int defense;
    private int speed;
    private int special;
    
    public int CurrentHP{ get; set; }
    public int CurrentAttack{ get; set; }
    public int CurrentDefense{ get; set; }
    public int CurrentSpeed{ get; set; }
    public int CurrentSpecial{ get; set; }

    public Stats(PokemonData data, int level)
    {
        this.Data = data;
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
        hp = Calculations.CalculateHP(Data.baseHP, level);
        attack = Calculations.CalculateStat(Data.baseAttack, level);
        defense = Calculations.CalculateStat(Data.baseDefense, level);
        speed = Calculations.CalculateStat(Data.baseSpeed, level);
        special = Calculations.CalculateStat(Data.baseSpecial, level);

        ResetStats();
    }
}
