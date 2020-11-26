//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoSingleton<MoveManager>, IManager
{
    private Dictionary<string, Move> moves = new Dictionary<string, Move>();

    public Move Move(string moveName)
    {
        return moves[moveName];
    }

    [SerializeField] private PokemonMoveKeyValuePairs[] pokemonMoveKeyValuePairs = default;

    [Serializable] public struct PokemonMoveKeyValuePairs
    {
        public string name;
        public Move move;
    }

    public void InitializeManager()
    {
        for (int i = 0; i < Instance.pokemonMoveKeyValuePairs.Length; i++)
        {
            Instance.moves.Add(Instance.pokemonMoveKeyValuePairs[i].name, Instance.pokemonMoveKeyValuePairs[i].move);
        }
    }
}
