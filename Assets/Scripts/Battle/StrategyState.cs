//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using PokemonBattle;
using UnityEngine;
using Random = UnityEngine.Random;

public class StrategyState : State<Battle>
{
    private DataTable<IBattleInterfaceItem> attacks;
    private DataTable<IBattleInterfaceItem> actions;
    private DataTable<IBattleInterfaceItem> currentInterface;
    public StrategyState(Battle owner) : base(owner)
    {
    }

    public override void Enter()
    {
        attacks = owner.playerCurrentPokemon.GetAttackTable();
        IBattleInterfaceItem[] battleInterfaces = new IBattleInterfaceItem[4];
        actions = new DataTable<IBattleInterfaceItem>(2,2,battleInterfaces);
        battleInterfaces[0] = attacks;
        currentInterface = actions;
    }

    public override void HandleCommand(InputCommand inputCommand)
    {
        if (inputCommand == InputCommand.A)
        {
            ExecuteSelection();
        }
        else if(inputCommand == InputCommand.B)
        {
            Debug.Log("Main menu");
            currentInterface = actions;
        }
        else
        {
            currentInterface.Navigate(inputCommand);
        }

        UpdateView();
    }

    public void ExecuteSelection()
    {
        IBattleInterfaceItem item = currentInterface.ConfirmSelection();

        if (item is Attack attack)
        {
            Debug.Log("Attack executed");
            HandleAttackCommand(attack);
        }
        else if (item is DataTable<IBattleInterfaceItem> table)
        {
            Debug.Log("Attack selected");
            HandleMenuCommand(table);
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

    private void HandleMenuCommand(DataTable<IBattleInterfaceItem> table)
    {
        currentInterface = table;
    }
    
    
    public void UpdateView()
    {
    }

    public override void Exit()
    {
    }
}