//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class GameManager : MonoSingleton<GameManager>, IManager
{
    private Battle currentBattle;
    private BattleView currentBattleView;
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
        Trainer player = new Trainer("Red");
        Pokemon bulbasaur = new Pokemon("Bulbasaur", 5);
        bulbasaur.IdNo = player.IdNo;
        bulbasaur.OriginalTrainer = player.Name;
        player.AddPokemon(bulbasaur);

        Trainer enemy = new Trainer("Blue");
        Pokemon charmander = new Pokemon("Charmander", 5);
        charmander.IdNo = enemy.IdNo;
        charmander.OriginalTrainer = enemy.Name;
        enemy.AddPokemon(charmander);
        
        StartBattle(player, enemy);
        
    }
    
    public void InitializeManager()
    {
        Application.targetFrameRate = 30;
        MoveManager.Instance.InitializeManager();
        PokemonManager.Instance.InitializeManager();
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

    private void StartBattle(Trainer player, Trainer enemy)
    {
        currentBattle = new Battle(player, enemy);
        currentBattleView = new BattleView(player, enemy, currentBattle);
        
        currentBattle.Initialize();
    }
}
