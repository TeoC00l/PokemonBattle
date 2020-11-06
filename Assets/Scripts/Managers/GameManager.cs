//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class GameManager : MonoSingleton<GameManager>, IManager
{
    private Battle currentBattle;

    public int actionValue;

    private int noOfActions = 4;

    private void Awake()
    {
        InitializeManager();
        DebugSceneSetup();
    }

    private void Update()
    {
        HandleInput();
    }

    private void DebugSceneSetup()
    {
        Trainer playerTrainer = new Trainer("Red");
        Pokemon bulbasaur = new Pokemon("Bulbasaur", 5);
        playerTrainer.AddPokemon(bulbasaur);

        Trainer enemyTrainer = new Trainer("Blue");
        Pokemon charmander = new Pokemon("Charmander", 5);
        enemyTrainer.AddPokemon(charmander);
        
        currentBattle = new Battle(playerTrainer, enemyTrainer);
    }
    
    public void InitializeManager()
    {
        Application.targetFrameRate = 30;
        
        MoveManager.Instance.InitializeManager();
        PokemonManager.Instance.InitializeManager();
    }

    public void HandleBattleAction(InputAction inputAction)
    {
        currentBattle.HandleCommand(inputAction);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HandleBattleAction(new InputAction(InputActionType.A));
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            HandleBattleAction(new InputAction(InputActionType.B));

        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HandleBattleAction(new InputAction(InputActionType.Up));
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HandleBattleAction(new InputAction(InputActionType.Down));
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandleBattleAction(new InputAction(InputActionType.Left));
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleBattleAction(new InputAction(InputActionType.Right));
        }
    }
}
