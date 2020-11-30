//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System.Collections.Generic;
using UnityEngine;

public class Battle : StateMachine<Battle>
{
    public Trainer player;
    public Trainer enemy;
    public Pokemon playerCurrentPokemon;
    public Pokemon enemyCurrentPokemon;

    private Pokemon[] playerPokemons;
    private Pokemon[] enemyPokemons;

    public delegate void PokemonDeployed(Pokemon pokemon);
    public event PokemonDeployed OnPokemonDeployed;

    public LinkedList<IBattleAction> battleActions = new LinkedList<IBattleAction>();

    public Battle(Trainer player, Trainer enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }

    public override void Initialize()
    {    
        stateDictionary.Add(typeof(StrategyState), new StrategyState(this));
        stateDictionary.Add(typeof(ActionState), new ActionState(this));

        playerPokemons = player.GetPokemon();
        DeployPokemon(playerPokemons[0]);
        //playerCurrentPokemon.OnFainted += OnPokemonFainted;
        
        enemyPokemons = enemy.GetPokemon();
        DeployPokemon(enemyPokemons[0]);
        
        currentState = stateDictionary[typeof(StrategyState)];
        currentState.Enter();
    }

    public void OnPokemonFainted(Pokemon pokemon)
    {
        Debug.Log(pokemon.Name + " has fainted.");
    }

    public void DeployPokemon(Pokemon pokemon)
    {
        if (pokemon.IdNo == player.IdNo && pokemon.OriginalTrainer == player.Name)
        {
            playerCurrentPokemon = pokemon;
            Debug.Log(player.Name + ": 'Go " + playerCurrentPokemon.Name +"!'");
        }
        else
        {
            enemyCurrentPokemon = pokemon;
            Debug.Log(enemy.Name + ": 'Go " + enemyCurrentPokemon.Name +"!'");
        }
        
        OnPokemonDeployed?.Invoke(pokemon);
    }
}
