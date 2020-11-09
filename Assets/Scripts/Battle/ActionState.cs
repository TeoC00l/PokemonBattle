//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

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
    }

    public override void HandleCommand(InputCommand inputCommand)
    {
        ExecuteBattleAction();
        owner.battleActions.Remove(currentAction);

        if (owner.battleActions.Count == 0)
        {
            owner.Transition<StrategyState>();
        }
        else
        {
            owner.Transition<ActionState>();
        }
        
        
        //TODO: Implement end battle state
    }

    public override void Exit()
    {
        UpdateView();
    }

    public void ExecuteBattleAction()
    {
        if (currentAction is Attack attack)
        {
            ExecuteAttack(attack);
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
    }

    public void UpdateView()
    {
        
    }
}