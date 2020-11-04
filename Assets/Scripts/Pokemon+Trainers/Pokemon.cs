//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Pokemon
{
    private string name;
    private int level;

    private Move[] moves = new Move[4];
    private PokemonType pokemonType;
    private Stats stats;
    private PokemonSprites sprites;

    public Pokemon(string name, int level)
    {
        this.name = name;
        this.level = level;
        
        stats = new Stats(PokemonManager.Instance.GetPokemonStats(name), level);
        moves[0] = MoveManager.Instance.Move("Tackle");
    }
}
