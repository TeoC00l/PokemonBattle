//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class BattleView : MonoSingleton<BattleView>
{
    [SerializeField] private Vector2 PlayerObjectDefaultPosition;
    [SerializeField] private Vector2 EnemyObjectDefaultPosition;
    
    [SerializeField] private Sprite PlayerHealthBar;
    [SerializeField] private Sprite EnemyHealthBar;
    [SerializeField] private Sprite DialogBox;
    [SerializeField] private Sprite Cursor;
    
    private Sprite CurrentPlayerObjectSprite;
    private Sprite CurrentEnemyObjectSprite;
}
