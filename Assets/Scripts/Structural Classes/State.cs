//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

public abstract class State<T> where T : StateMachine<T>
{
    protected T owner;

    public State(T owner)
    {
        this.owner = owner;
    }
    
    public abstract void Enter();
    
    public abstract void HandleCommand(InputCommand inputCommand);
    
    public abstract void Exit();
}
