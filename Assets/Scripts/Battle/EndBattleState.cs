//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public class EndBattleState : State<Battle>
{
    public Trainer winner;
    
    public EndBattleState(Battle owner) : base(owner)
    {
    }

    public override void Enter()
    {
    }

    public override void HandleCommand(InputCommand inputCommand)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}
