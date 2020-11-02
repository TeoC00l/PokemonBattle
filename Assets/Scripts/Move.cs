//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu


using UnityEngine;

[CreateAssetMenu(fileName = "PkmnMove", menuName = "Move")]
public class Move: ScriptableObject
{
    public string Name { get; private set; }
    public PokemonType damageType { get; private set; }
    public int power { get; private set; }
    public int accuracy { get; private set; }
    public int PP { get; private set; }
}
