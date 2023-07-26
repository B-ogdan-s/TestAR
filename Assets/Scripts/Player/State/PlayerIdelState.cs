internal class PlayerIdelState : PlayerState
{
    public PlayerIdelState(PlayerComponentData componentData) : base(componentData) { }

    public override void StartMove()
    {
        ChangeState?.Invoke(typeof(PlayerMoveState));
    }
}

