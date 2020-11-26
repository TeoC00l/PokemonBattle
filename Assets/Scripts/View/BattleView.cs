//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using Unity.Mathematics;
using UnityEngine;

public class BattleView : MonoSingleton<BattleView>, IManager
{
    [Header("Player Default Positions")]
    [SerializeField] private Vector2 playerObjectDefaultPosition;
    [SerializeField] private Vector2 playerHealthBarDefaultPosition;
    [SerializeField] private Vector2 dialogBoxDefaultPosition;

    [Header("Enemy Default Positions")]
    [SerializeField] private Vector2 enemyObjectDefaultPosition;
    [SerializeField] private Vector2 enemyHealthBarDefaultPosition;
    
    [SerializeField] private Sprite playerHealthBar;
    [SerializeField] private Sprite enemyHealthBar;
    [SerializeField] private Sprite dialogBox;
    [SerializeField] private Sprite cursor;
    
    private Sprite currentPlayerObjectSprite;
    private Sprite currentEnemyObjectSprite;
    private Sprite currentMenu;


    public void InitializeManager()
    {
        Instantiate(dialogBox, dialogBoxDefaultPosition, quaternion.identity);
    }
}
