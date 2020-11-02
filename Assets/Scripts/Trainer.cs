//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class Trainer
{
    private string name;
    private Pokemon[] pokemons = new Pokemon[5];
    public int NoOfPokemon {private set; get; }

    private static int MAX_POKEMONS = 6;
    private static int MIN_POKEMONS = 1;

    public Trainer(string name)
    {
        name = this.name;
        NoOfPokemon = default;
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
}
