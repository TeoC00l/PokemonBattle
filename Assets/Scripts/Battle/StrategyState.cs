//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using PokemonBattle;
using UnityEngine;
using Random = UnityEngine.Random;

public class StrategyState : State<Battle>
{
    private DataTable<IBattleInterfaceItem> attacks;
    private DataTable<IBattleInterfaceItem> menuActions;
    private DataTable<IBattleInterfaceItem> currentInterface;
    public StrategyState(Battle owner) : base(owner)
    {
    }

    public override void Enter()
    {
        attacks = owner.playerCurrentPokemon.GetAttackTable();
        IBattleInterfaceItem[] battleInterfaces = new IBattleInterfaceItem[4];
        battleInterfaces[0] = attacks;
        menuActions = new DataTable<IBattleInterfaceItem>(2,2,battleInterfaces);
        
        EnterActionMenuSubState();
    }

    public override void HandleCommand(InputCommand inputCommand)
    {
        if (inputCommand == InputCommand.A)
        {
            ExecuteSelection();
        }
        else if(inputCommand == InputCommand.B)
        {
            EnterActionMenuSubState();
        }
        else
        {
            currentInterface.Navigate(inputCommand);
        }
    }

    public void ExecuteSelection()
    {
        IBattleInterfaceItem item = currentInterface.ConfirmSelection();

        if (item is Attack attack)
        {
            Debug.Log("Attack selected");
            HandleAttackCommand(attack);
        }
        else if (item is DataTable<IBattleInterfaceItem> table)
        {
            EnterAttackMenuSubState(table);
        }
    }

    public void HandleAttackCommand(Attack attack)
    {
        owner.battleActions.AddFirst(attack);
        Attack enemyAttack = GetEnemyAttack();
        
        if (enemyAttack.speed > attack.speed)
        {
            owner.battleActions.AddFirst(enemyAttack);
        }
        else
        {
            owner.battleActions.AddLast(enemyAttack);
        }

        owner.Transition<ActionState>();
    }

    public Attack GetEnemyAttack()
    {
        Pokemon enemyPokemon = owner.enemyCurrentPokemon;
        int moveIndex = Random.Range(0, enemyPokemon.GetNoOfMoves());
        return enemyPokemon.GetAttack(moveIndex);
    }

    private void EnterAttackMenuSubState(DataTable<IBattleInterfaceItem> table)
    {
        Debug.Log("Attack substate entered");
        currentInterface = table;
    }

    public void EnterActionMenuSubState()
    {
        Debug.Log(("Select a menu option"));
        currentInterface = menuActions;
    }

    public override void Exit()
    {
    }
}