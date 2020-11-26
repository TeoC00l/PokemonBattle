//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEditor.Profiling;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>, IManager
{
    private Battle currentBattle;

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
        BattleView.Instance.InitializeManager();
    }

    public void HandleBattleAction(InputCommand inputCommand)
    {
        currentBattle.HandleCommand(inputCommand);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HandleBattleAction(InputCommand.A);
        }
        
        else if (Input.GetKeyDown(KeyCode.B))
        {
            HandleBattleAction(InputCommand.B);

        }
        
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HandleBattleAction(InputCommand.Up);
        }
        
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HandleBattleAction(InputCommand.Down);
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HandleBattleAction(InputCommand.Left);
        }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HandleBattleAction(InputCommand.Right);
        }
    }
}
