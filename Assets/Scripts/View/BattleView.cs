//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;
using UnityEngine.Assertions;

public class BattleView
{
    private readonly BattleViewElements elements;
    private readonly Battle battle;

    private readonly Trainer player;
    private readonly Trainer enemy;

    private ViewSpriteElement currentPlayerObject;
    private ViewSpriteElement currentEnemyObject;
    
    private ViewSpriteElement currentMenu;
    private ViewSpriteElement dialogBoxObject;
    private ViewSpriteElement overlayObject;
    private ViewSpriteElement canvasObject;

    private ViewTextElement playerObjectNameText;
    private ViewTextElement enemyObjectNameText;


    public BattleView(Trainer player, Trainer enemy, Battle battle)
    {
        Assert.IsNotNull(elements = GameManager.FindObjectOfType<BattleViewElements>());

        this.player = player;
        this.enemy = enemy;
        this.battle = battle;
        SetupElements();
    }

    private void SetupElements()
    {
        currentPlayerObject = new ViewSpriteElement(null, elements.playerObjectDefaultPosition);
        currentEnemyObject = new ViewSpriteElement(null, elements.enemyObjectDefaultPosition);
        dialogBoxObject = new ViewSpriteElement(elements.dialogBox, elements.dialogBoxDefaultPosition);
        overlayObject = new ViewSpriteElement(elements.overlay, elements.overlayDefaultPosition);
        playerObjectNameText = new ViewTextElement("", elements.playerPokemonNamePosition);
        enemyObjectNameText = new ViewTextElement("", elements.enemyPokemonNamePosition);

        currentPlayerObject.SetActive = true;
        currentEnemyObject.SetActive = true;
        overlayObject.SetActive = true;
        dialogBoxObject.SetActive = true;
        
        battle.OnPokemonDeployed += DeployPokemon;
    }

    private void DeployPokemon(Pokemon pokemon)
    {
        if (pokemon.IdNo == player.IdNo && pokemon.OriginalTrainer == player.Name)
        {
            UpdatePlayerElements(pokemon.Name, pokemon.backSprite);
        }
        else
        {
            UpdateEnemyElements(pokemon.Name, pokemon.frontSprite);
        }
    }

    private void UpdatePlayerElements(string name, Sprite sprite)
    {
        currentPlayerObject.ChangeGraphic(sprite);
        playerObjectNameText.ChangeText(name);
    }

    private void UpdateEnemyElements(string name, Sprite sprite)
    {
        currentEnemyObject.ChangeGraphic(sprite);
        enemyObjectNameText.ChangeText(name);
    }
}
