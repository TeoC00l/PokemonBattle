//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Trainer
{
    public string Name { get; private set; }
    public int IdNo { get; private set; }
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
        IdNo = Random.Range(0,10000);
    }
    
    public void AddPokemon(Pokemon pokemon)
    {
        if (pokemons.Length >= MAX_POKEMONS)
        {
            Debug.LogError("TOO MANY POKEMON");
            return;
        }

        pokemon.OriginalTrainer = Name;
        pokemon.IdNo = IdNo;

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

    public Pokemon[] GetPokemon()
    {
        return pokemons;
    }

    public void OnPokemonFainted(Pokemon pokemon)
    {
        NoOfActivePokemon--;
    }
    
    
}
