//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class GameManager : MonoSingleton<GameManager>, IManager
{
    
    private void Awake()
    {
        InitializeManager();
        DebugSceneSetup();
    }

    private static void DebugSceneSetup()
    {
        Trainer playerTrainer = new Trainer("Red");
        Pokemon bulbasaur = new Pokemon("Bulbasaur", 5);
        playerTrainer.AddPokemon(bulbasaur);

        Trainer enemyTrainer = new Trainer("Blue");
        Pokemon charmander = new Pokemon("Charmander", 5);
        enemyTrainer.AddPokemon(charmander);
    }


    public void InitializeManager()
    {
        Application.targetFrameRate = 30;
        
        MoveManager.Instance.InitializeManager();
        PokemonManager.Instance.InitializeManager();
        
        
    }
}
