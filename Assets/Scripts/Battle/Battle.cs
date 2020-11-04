﻿//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public class Battle : StateMachine
{
    private Trainer player;
    private Trainer enemy;
    private Pokemon playerCurrentPokemon;
    private Pokemon enemyCurrentPokemon;
    
    public override void Initialize()
    {
        stateDictionary.Add(typeof(StrategyState), new StrategyState(this));
        stateDictionary.Add(typeof(AttackState), new AttackState(this));
    }
}
