public abstract class PlayerState : State
{
    public PlayerState(PlayerComponentData componentData)
    {
        _componentData = componentData;
    }

    protected PlayerComponentData _componentData;

    public virtual void Update() { }
    public virtual void Fixedupdate() { }

    public virtual void StartMove() { }
    public virtual void StopMove() { }
}


