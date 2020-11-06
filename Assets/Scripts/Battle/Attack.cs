//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public struct Attack: IBattleInterfaceItem
{
    public int damage;
    public int accuracy;
    public int speed;
    public PokemonType damageType;

    public Attack(int damage, int accuracy, int speed, PokemonType damageType)
    {
        this.damage = damage;
        this.accuracy = accuracy;
        this.speed = speed;
        this.damageType = damageType;
    }
}
