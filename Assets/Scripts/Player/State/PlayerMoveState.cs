using UnityEngine;

internal class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerComponentData componentData) : base(componentData) { }

    public override void Fixedupdate()
    {
        _componentData.PlayerMove.Move();
    }
    public override void Update()
    {
        _componentData.PlayerMove.Rotate();
    }

    public override void StopMove()
    {
        ChangeState?.Invoke(typeof(PlayerIdelState));
    }

    public override void Enter()
    {
        _componentData.JoystickTouche.OnUpdateDirection += _componentData.PlayerMove.SetRotateDirection;
    }
    public override void Exit()
    {
        _componentData.JoystickTouche.OnUpdateDirection -= _componentData.PlayerMove.SetRotateDirection;
        _componentData.PlayerMove.RemoveSpeedValue();
    }
}