//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

[CreateAssetMenu(fileName = "PkmnMove", menuName = "Move")]
public class Move: ScriptableObject
{
    public PokemonType damageType;
    public int power;
    public int accuracy;
    public int PP;
}
