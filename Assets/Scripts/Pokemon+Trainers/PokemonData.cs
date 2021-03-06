﻿//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

[CreateAssetMenu(fileName = "PkmnBaseStats", menuName = "BaseStats")]
public class PokemonData : ScriptableObject
{
    public string name;
    public Sprite frontSprite;
    public Sprite backSprite;
    
    public int baseHP;
    public int baseAttack;
    public int baseDefense;
    public int baseSpeed;
    public int baseSpecial;
    
    public PokemonType pokemonType;
}
