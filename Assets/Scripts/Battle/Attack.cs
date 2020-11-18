//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public struct Attack: IBattleInterfaceItem, IBattleAction
{
    
    public string Name { get; set; }
    public int damage;
    public int accuracy;
    public int speed;
    public PokemonType damageType;
    public Pokemon attacker;

    public Attack(string name, int damage, int accuracy, int speed, PokemonType damageType, Pokemon attacker)
    {
        Name = name;
        this.damage = damage;
        this.accuracy = accuracy;
        this.speed = speed;
        this.damageType = damageType;
        this.attacker = attacker;
    }

}
