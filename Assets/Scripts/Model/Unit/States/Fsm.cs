using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;

public class Fsm
{
    private State _currentState;

    private Dictionary<Type, State> _states = new Dictionary<Type, State>();

    public void AddState(State state)
    {
        if(_states.ContainsKey(state.GetType()))
        {
            return;
        }

        _states.Add(state.GetType(), state);
    }

    public void SetState(State nextState ,InputAction input = null)
    {
        if(_currentState == nextState)
        {
            return;
        }

        if(_states.Values.Contains(nextState))
        {
            _currentState = nextState;
        }
    }

    public void Update()
    {
        _currentState.Update();
    }
}
