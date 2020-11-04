//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;

public abstract class StateMachine
{
    protected State[] states;
    protected State currentState;
    protected Dictionary<Type, State> stateDictionary = new Dictionary<Type, State>();
    
    public abstract void Initialize();

    public void Transition<T>() where T : State
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }
}
