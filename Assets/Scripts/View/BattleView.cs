//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class BattleView : MonoSingleton<BattleView>, IManager
{
    [Header("Text")]
    [SerializeField] private GameObject pkmnTextObjectPrefab;
    [SerializeField] private Vector2 textSize;
    [SerializeField] private Vector2 dialogBoxTextPosition;
    [SerializeField] private Vector2 enemyPokemonNamePosition;
    [SerializeField] private Vector2 playerPokemonNamePosition;
    [SerializeField] private Vector2 playerLevelPosition;
    [SerializeField] private Vector2 enemyLevelPosition;
    
    [Header("Default Positions")]
    [SerializeField] private Vector2 playerObjectDefaultPosition;
    [SerializeField] private Vector2 enemyObjectDefaultPosition;
    [SerializeField] private Vector2 playerHealthBarDefaultPosition;
    [SerializeField] private Vector2 enemyHealthBarDefaultPosition;
    [SerializeField] private Vector2 dialogBoxDefaultPosition;
    [SerializeField] private Vector2 overlayDefaultPosition;

    [Header("Sprites")]
    [SerializeField] private Sprite dialogBox;
    [SerializeField] private Sprite cursor;
    [SerializeField] private Sprite overlay;
    
    private Sprite currentPlayerObjectSprite;
    private Sprite currentEnemyObjectSprite;
    private Sprite currentMenu;
    private GameObject dialogBoxObject;
    private GameObject overlayObject;
    private GameObject canvasObject;
    public void InitializeManager()
    {
        dialogBoxObject = SetupSceneObject(dialogBox, dialogBoxDefaultPosition);
        overlayObject = SetupSceneObject(overlay, overlayDefaultPosition);
        canvasObject = GameObject.FindWithTag("MainCanvas");
    }

    private GameObject SetupSceneObject(Sprite sprite, Vector2 defaultPosition)
    {
        GameObject sceneObject = new GameObject();
        sceneObject.AddComponent<SpriteRenderer>().sprite = sprite;
        sceneObject.transform.position = defaultPosition;

        return sceneObject;
    }
}
