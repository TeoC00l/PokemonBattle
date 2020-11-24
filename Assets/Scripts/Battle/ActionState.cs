//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class ActionState : State<Battle>
{
    private IBattleAction currentAction;
    
    private Pokemon playerPokemon;
    private Pokemon enemyPokemon;
    
    public ActionState(Battle owner) : base(owner)
    {
    }

    public override void Enter()
    {
        currentAction = owner.battleActions.First.Value;
        playerPokemon = owner.playerCurrentPokemon;
        enemyPokemon = owner.enemyCurrentPokemon;
        
        ExecuteBattleAction();
        Transition();
    }

    public void ExecuteBattleAction()
    {
        if (currentAction is Attack attack)
        {
            ExecuteAttack(attack);
        }
        
        owner.battleActions.RemoveFirst();
    }

    public void Transition()
    {
        
        if (owner.battleActions.Count == 0)
        {
            Debug.Log(owner.playerCurrentPokemon.Name + " hp: " + owner.playerCurrentPokemon.Stats.CurrentHP);
            Debug.Log(owner.enemyCurrentPokemon.Name + " hp: " + owner.enemyCurrentPokemon.Stats.CurrentHP);
            owner.Transition<StrategyState>();
        }
        else
        {
            owner.Transition<ActionState>();
        }
    }

    public void ExecuteAttack(Attack attack)
    {
        Pokemon target;

        if (owner.playerCurrentPokemon == attack.attacker)
        {
            target = enemyPokemon;
        }
        else
        {
            target = playerPokemon;
        }
        
        Debug.Log(attack.attacker.Name + " used " + attack.Name + ".");
        target.RecieveAttack(attack);
    }
    
    
    public override void HandleCommand(InputCommand inputCommand)
    {
    }

    public override void Exit()
    {
    }

}