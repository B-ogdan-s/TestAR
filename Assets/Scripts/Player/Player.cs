using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private InputJoystickTouche _inputJoystickTouche;
    [SerializeField] private PlayerComponentData _playerData;

    private StateMachine<PlayerState> _stateMachine;
    private Vector3 _startLocalPos;

    private void Awake()
    {
        _startLocalPos = transform.localPosition;

        _playerData.EntityHealth.OnDead += Dead;

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

    private void Dead()
    {
        Debug.Log("Player Dead");
    }


    private void InitializeStateMachine()
    {
        List<PlayerState> states = new List<PlayerState>()
        {
            new PlayerIdelState(_playerData),
            new PlayerMoveState(_playerData)
        };

        _stateMachine = new StateMachine<PlayerState>(states.ToArray());

        _stateMachine.ChangeState(typeof(PlayerIdelState));
    }

    public void OnTargetFound()
    {
        transform.localPosition = _startLocalPos;
        transform.localEulerAngles = Vector3.zero;

        _playerData.JoystickTouche.OnStartMove += StartMove;
        _playerData.JoystickTouche.OnStopMove += StopMove;
        _playerData.JoystickTouche.OnUpdateDirection += _playerData.PlayerMove.SetMoveDirection;
    }
    public void OnTargetLost()
    {
        _playerData.JoystickTouche.OnStartMove -= StartMove;
        _playerData.JoystickTouche.OnStopMove -= StopMove;
        _playerData.JoystickTouche.OnUpdateDirection -= _playerData.PlayerMove.SetMoveDirection;
    }
}
