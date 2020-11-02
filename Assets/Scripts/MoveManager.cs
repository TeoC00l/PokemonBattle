//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    private Dictionary<string, Move> moves = new Dictionary<string, Move>();

    public Move Move(string moveName)
    {
        return moves[moveName];
    }
    

    [SerializeField] private PokemonMoveKeyValuePairs[] pokemonMoveKeyValuePairs = default;

    public static MoveManager instance;

    [Serializable]
    public struct PokemonMoveKeyValuePairs
    {
        public string name;
        public Move move;
    }
}
