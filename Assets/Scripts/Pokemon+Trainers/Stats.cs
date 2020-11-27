//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Stats
{
    private PokemonData _pokemonData;

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

    public Stats(PokemonData pokemonData, int level)
    {
        this._pokemonData = pokemonData;
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
        hp = Calculations.CalculateHP(_pokemonData.baseHP, level);
        attack = Calculations.CalculateStat(_pokemonData.baseAttack, level);
        defense = Calculations.CalculateStat(_pokemonData.baseDefense, level);
        speed = Calculations.CalculateStat(_pokemonData.baseSpeed, level);
        special = Calculations.CalculateStat(_pokemonData.baseSpecial, level);

        ResetStats();
    }
}
