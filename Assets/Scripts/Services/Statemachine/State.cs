using System;

public abstract class State
{
    public Action<Type> ChangeState;

    public virtual void Enter() { }
    public virtual void Exit() { }

}

