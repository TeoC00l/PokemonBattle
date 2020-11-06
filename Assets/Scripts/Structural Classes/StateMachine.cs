﻿//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T> where T : StateMachine<T>
{
    protected State<T> currentState;
    protected Dictionary<Type, State<T>> stateDictionary = new Dictionary<Type, State<T>>();
    
    public abstract void Initialize();

    public void Transition<StateType>() where StateType : State<T>
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    public bool HandleCommand(InputCommand inputCommand)
    {
        return currentState.HandleCommand(inputCommand);
    }
}
