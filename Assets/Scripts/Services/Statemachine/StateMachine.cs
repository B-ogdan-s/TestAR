using System;
using System.Collections.Generic;

internal class StateMachine<StateType> where StateType : State
{
    private Dictionary<Type, StateType> _stateDictionary = new Dictionary<Type, StateType>();
    private StateType _state;

    public StateType State => _state;

    public StateMachine(StateType[] playerStates)
    {
        for(int i = 0; i < playerStates.Length; i++)
        {
            _stateDictionary.Add(playerStates[i].GetType(), playerStates[i]);
            playerStates[i].ChangeState += ChangeState;
        }
    }

    public void ChangeState(Type newState)
    {
        _state?.Exit();
        _state = _stateDictionary[newState];
        _state?.Enter();
    }
}
