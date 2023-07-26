internal class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerComponentData componentData) : base(componentData) { }

    public override void Fixedupdate()
    {
        _componentData.PlayerMove.Move();
    }

    public override void StopMove()
    {
        ChangeState?.Invoke(typeof(PlayerIdelState));
    }

    public override void Exit()
    {
        _componentData.PlayerMove.RemoveSpeedValue();
    }
}