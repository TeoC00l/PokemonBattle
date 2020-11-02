//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Pokemon
{
    private string name;
    private int level;

    private Move[] moves;
    private PokemonType pokemonType;
    private Stats stats;
    private PokemonSprites sprites;

    public Pokemon(string name, int level)
    {
        this.name = name;
        this.level = level;
        
        stats = new Stats(PokemonManager.instance.GetPokemonStats(name), level);
        moves[0] = MoveManager.instance.Move("Tackle");
    }
    
}
