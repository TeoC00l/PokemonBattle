//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

public abstract class State
{
    private StateMachine owner;

    public State(StateMachine owner)
    {
        this.owner = owner;
    }
    
    public abstract void Enter();
    
    public abstract void Update();
    
    public abstract void Exit();
}
