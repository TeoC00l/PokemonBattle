//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System.Collections.Generic;
using UnityEngine;

public class Battle : StateMachine<Battle>
{
    public Trainer player;
    public Trainer enemy;
    public Pokemon playerCurrentPokemon;
    public Pokemon enemyCurrentPokemon;

    public LinkedList<IBattleAction> battleActions = new LinkedList<IBattleAction>();

    public Battle(Trainer player, Trainer enemy)
    {
        this.player = player;
        this.enemy = enemy;
        
        Initialize();
    }

    public override void Initialize()
    {    
        stateDictionary.Add(typeof(StrategyState), new StrategyState(this));
        stateDictionary.Add(typeof(ActionState), new ActionState(this));

        playerCurrentPokemon = player.GetPokemon(0);
        Debug.Log("Go " + playerCurrentPokemon.Name +"!");
        
        playerCurrentPokemon.OnFainted += OnPokemonFainted;
        enemyCurrentPokemon = enemy.GetPokemon(0);
        Debug.Log("Go " + playerCurrentPokemon.Name +"!");
        
        currentState = stateDictionary[typeof(StrategyState)];
        currentState.Enter();
    }

    public void OnPokemonFainted(Pokemon pokemon)
    {
        Debug.Log(pokemon.Name + " has fainted.");
        Debug.Log("...And  thus ends our pokemon experience, because the system has to be expanded upon.");
    }
}
