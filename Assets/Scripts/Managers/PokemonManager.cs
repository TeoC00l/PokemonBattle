//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PokemonManager :  MonoSingleton<PokemonManager>, IManager
{
    private Dictionary<string, PokemonData> pokemonStats = new Dictionary<string, PokemonData>();

    [SerializeField] private PokemonBaseStatKeyValuePairs[] PokemonBaseStatList = default;
    
    [Serializable] public struct PokemonBaseStatKeyValuePairs
    {
        public string name;
        public PokemonData pokemonData;
    }
    
    public PokemonData GetPokemonStats(string name)
    {
        Assert.IsTrue(pokemonStats.ContainsKey(name));

        return pokemonStats[name];
    }

    public void InitializeManager()
    {
        for (int i = 0; i < PokemonBaseStatList.Length; i++)
        {
            pokemonStats.Add(PokemonBaseStatList[i].name, PokemonBaseStatList[i].pokemonData);
        }
    }
}
