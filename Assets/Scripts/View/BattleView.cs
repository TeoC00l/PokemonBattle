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
        currentPlayerObject = new ViewSpriteElement(elements.dialogBox, elements.playerObjectDefaultPosition);
        currentEnemyObject = new ViewSpriteElement(elements.dialogBox, elements.enemyObjectDefaultPosition);
        dialogBoxObject = new ViewSpriteElement(elements.dialogBox, elements.dialogBoxDefaultPosition);
        overlayObject = new ViewSpriteElement(elements.overlay, elements.overlayDefaultPosition);

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
            Debug.Log("YES");
            currentPlayerObject.ChangeGraphic(pokemon.backSprite);
        }
        else
        {
            Debug.Log("ye");
            currentEnemyObject.ChangeGraphic(pokemon.frontSprite);
        }
    }
    
    
}
