//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public static class Calculations
{
    public static int CalculateStat(int baseStatLevel, int level)
    {
        return baseStatLevel + (baseStatLevel * level) / 50;
    }
    
    public static int CalculateHP(int baseStatHPLevel, int level)
    {
        return baseStatHPLevel * level * 2 + level + 10;
    }
}
