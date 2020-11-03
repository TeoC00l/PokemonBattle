//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PokemonManager : Manager<PokemonManager>
{
    private Dictionary<string, BaseStats> pokemonStats = new Dictionary<string, BaseStats>();

    [SerializeField] private PokemonBaseStatKeyValuePairs[] PokemonBaseStatList = default;
    
    [Serializable] public struct PokemonBaseStatKeyValuePairs
    {
        public string name;
        public BaseStats baseStats;
    }
    
    public BaseStats GetPokemonStats(string name)
    {
        Assert.IsTrue(pokemonStats.ContainsKey(name));

        return pokemonStats[name];
    }

    public override void InitializeManager()
    {
        for (int i = 0; i < PokemonBaseStatList.Length; i++)
        {
            pokemonStats.Add(PokemonBaseStatList[i].name, PokemonBaseStatList[i].baseStats);
        }
    }
}
