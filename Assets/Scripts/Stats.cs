//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Stats
{
    private int baseHP;
    private int baseStamina;
    private int baseAttack;
    private int baseDefense;
    private int baseSpeed;
    private int baseSpecial;
    
    private int currentHP;
    private int currentStamina;
    private int currentAttack;
    private int currentDefense;
    private int currentSpeed;
    private int currentSpecial;

    public Stats(int hp, int stamina, int attack, int defense, int speed, int special)
    {
        baseHP = hp;
        baseStamina = stamina;
        baseAttack = attack;
        baseDefense = defense;
        baseSpeed = speed;
        baseSpecial = special;

        ResetStats();
    }

    public void ResetStats()
    {
        currentHP = baseHP;
        currentStamina = baseStamina;
        currentAttack = baseAttack;
        currentDefense = baseDefense;
        currentSpeed = baseSpeed;
        currentSpecial = baseSpecial;
    }
}
