//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using PokemonBattle;

public class StrategyState : State<Battle>
{
    private DataTable<IBattleInterfaceItem> attacks;
    private DataTable<IBattleInterfaceItem> dataTables;

    private DataTable<IBattleInterfaceItem> currentInterface;
    public StrategyState(Battle owner) : base(owner)
    {
    }

    public override void Enter()
    {
        attacks = owner.playerCurrentPokemon.GetAttackTable();
        IBattleInterfaceItem[] battleInterfaces = new IBattleInterfaceItem[1];
        battleInterfaces[0] = attacks;
        dataTables = new DataTable<IBattleInterfaceItem>(2,2,battleInterfaces);

        currentInterface = dataTables;
    }

    public override bool HandleCommand(InputCommand inputCommand)
    {
        if (inputCommand == InputCommand.A)
        {
            
        }
        
        else if (inputCommand == InputCommand.B)
        {
            
        }
        else
        {
            
        }
    }

    public bool HandleAttackCommand(InputCommand inputCommand)
    {
        if (inputCommand == InputCommand.A)
        {
            
        }
        
        else if (inputCommand == InputCommand.B)
        {
            
        }
        else
        {
            
        }
    }

    private bool HandleMenuCommand(InputCommand inputCommand)
    {
        if (inputCommand == InputCommand.A)
        {
            
        }
        
        else if (inputCommand == InputCommand.B)
        {
            
        }
        else
        {
            
        }
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}