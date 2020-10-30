//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

[CreateAssetMenu(fileName = "PkmnBaseStats", menuName = "BaseStats")]
public class BaseStats : ScriptableObject
{
    public int baseHP;
    public int baseStamina;
    public int baseAttack;
    public int baseDefense;
    public int baseSpeed;
    public int baseSpecial;
}
