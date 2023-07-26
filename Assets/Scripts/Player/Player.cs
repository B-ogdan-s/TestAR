using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputJoystickTouche _inputJoystickTouche;
    [SerializeField] private PlayerComponentData _playerData;

    private StateMachine<PlayerState> _stateMachine;
    private Vector3 _startLocalPos;

    private void Awake()
    {
        _startLocalPos = transform.localPosition;

        InitializeStateMachine();
    }

    private void FixedUpdate()
    {
        _stateMachine.State.Fixedupdate();
    }
    private void Update()
    {
        _stateMachine.State.Update();
    }

    private void StartMove()
    {
        _stateMachine.State.StartMove();
    }
    private void StopMove()
    {
        _stateMachine.State.StopMove();
    }

    private void SetDirectionMove(Vector2 direction)
    {
        _playerData.PlayerMove.SetDirection(direction);
    }


    private void InitializeStateMachine()
    {
        List<PlayerState> playerStates = new List<PlayerState>()
        {
            new PlayerIdelState(_playerData),
            new PlayerMoveState(_playerData)
        };

        _stateMachine = new StateMachine<PlayerState>(playerStates.ToArray());

        _stateMachine.ChangeState(typeof(PlayerIdelState));
    }

    public void OnTargetFound()
    {
        transform.localPosition = _startLocalPos;
        transform.localEulerAngles = Vector3.zero;

        _inputJoystickTouche.OnStartMove += StartMove;
        _inputJoystickTouche.OnStopMove += StopMove;
        _inputJoystickTouche.OnUpdateDirection += SetDirectionMove;
    }
    public void OnTargetLost()
    {
        _inputJoystickTouche.OnStartMove -= StartMove;
        _inputJoystickTouche.OnStopMove -= StopMove;
        _inputJoystickTouche.OnUpdateDirection -= SetDirectionMove;
    }
}
