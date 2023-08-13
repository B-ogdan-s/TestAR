using UnityEngine;

public abstract class PlayerState : State
{
    protected PlayerComponentData _componentData;

    public PlayerState(PlayerComponentData componentData)
    {
        _componentData = componentData;
    }

    public virtual void Update() { }
    public virtual void Fixedupdate() { }

    public virtual void StartMove() { }
    public virtual void StopMove() { }
}


