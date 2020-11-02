//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PokemonManager : MonoBehaviour
{
    private Dictionary<string, BaseStats> pokemonStats = new Dictionary<string, BaseStats>();

    [SerializeField] private PokemonBaseStatKeyValuePairs[] PokemonBaseStatList = default;

    public static PokemonManager instance;
    
    [Serializable] public struct PokemonBaseStatKeyValuePairs
    {
        public string name;
        public BaseStats baseStats;
    }
  
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < PokemonBaseStatList.Length; i++)
        {
            pokemonStats.Add(PokemonBaseStatList[i].name, PokemonBaseStatList[i].baseStats);
        }
    }

    public BaseStats GetPokemonStats(string name)
    {
        Assert.IsTrue(pokemonStats.ContainsKey(name));

        return pokemonStats[name];
    }
}
