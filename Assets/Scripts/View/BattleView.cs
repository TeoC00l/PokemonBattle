//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using PokemonBattle;
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
    
    private ViewDataTable currentMenu;
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

        battle.OnPokemonDeployed += DeployPokemon;
        battle.OnDataTableChanged += UpdateDataTableViewElements;
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

    private void UpdateDataTableViewElements(DataTable<IBattleInterfaceItem> dataTable)
    {
        if (currentMenu == null)
        {
            currentMenu = new ViewDataTable(dataTable, 1f,1f, elements.dialogBox, elements.actionMenuPosition);
        }
        else if (dataTable.Name == currentMenu.Name)
        {
            UpdateCursor(dataTable);
            return;
        }
        
        
    }

    private void UpdateCursor(DataTable<IBattleInterfaceItem> dataTable)
    {
        
    }
}
