using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State
{
    protected readonly Fsm Fsm;
    protected readonly List<Condition> Conditions;

    public State(Fsm fsm)
    {
        Fsm = fsm;
        Conditions = new List<Condition>();
    }

    public virtual void Update()
    {
        foreach (var condition in Conditions)
        {
            if (condition.CanTransit())
            {
                Fsm.SetState(condition.TargetState);
                return;
            }
        }
    }

    public void AddCondition(Condition condition)
    {
        Conditions.Add(condition);
    }
}
