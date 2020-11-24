//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using Debug = UnityEngine.Debug;

public class Trainer
{
    public string Name { get; private set; }
    private Pokemon[] pokemons = new Pokemon[5];
    public int NoOfPokemon {private set; get; }
    public int NoOfActivePokemon { private set; get; }

    private static int MAX_POKEMONS = 6;
    private static int MIN_POKEMONS = 1;

    public Trainer(string name)
    {
        Name = name;
        NoOfPokemon = default;
        NoOfActivePokemon = default;
    }
    
    public void AddPokemon(Pokemon pokemon)
    {
        if (pokemons.Length >= MAX_POKEMONS)
        {
            Debug.LogError("TOO MANY POKEMON");
            return;
        }

        pokemons[NoOfPokemon] = pokemon;
        NoOfPokemon++;
        NoOfActivePokemon++;

    }

    public void RemovePokemon(Pokemon pokemon)
    {
        if (pokemons.Length <= MIN_POKEMONS)
        {
            Debug.LogError("TOO FEW POKEMON");
            return;
        }
        //TODO: IMPLEMENT
    }

    public Pokemon GetPokemon(int index)
    {
        return pokemons[index];
    }

    public void OnPokemonFainted(Pokemon pokemon)
    {
        NoOfActivePokemon--;
    }
    
    
}
