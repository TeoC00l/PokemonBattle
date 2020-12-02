//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class BattleViewElements : MonoSingleton<BattleViewElements>
{
    [Header("Text")] 
    public Vector2 textSize;
    public Vector2 dialogBoxTextPosition;
    public Vector2 actionMenuPosition;
    public Vector2 enemyPokemonNamePosition;
    public Vector2 playerPokemonNamePosition;
    public Vector2 playerLevelPosition;
    public Vector2 enemyLevelPosition;
    public GameObject canvas;
    public Font font;
    public int fontSize;
    public int menuPadding;

    [Header("Default Positions")] public Vector2 playerObjectDefaultPosition;
    public Vector2 enemyObjectDefaultPosition;
    public Vector2 dialogBoxDefaultPosition;
    public Vector2 overlayDefaultPosition;
    public Vector2 horizontalCursorDefaultOffset;

    [Header("Sprites")] public Sprite dialogBox;
    public Sprite cursor;
    public Sprite overlay;

    private Sprite currentMenu;
    private GameObject dialogBoxObject;
    private GameObject overlayObject;
    private GameObject canvasObject;

    [Header("Healthbars")] 
    public int healthBarWidth;
    public int healthBarHeight;
    public Vector2 playerHealthBarDefaultPosition;
    public Vector2 enemyHealthBarDefaultPosition;


}
