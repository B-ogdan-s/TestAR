using System.Collections.Generic;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyComponentData _enemyData;
    private Player _player;
    private StateMachine<EnemyState> _stateMachine;

    private void Awake()
    {
        _enemyData.EnemyAttack.StartAttack += StartAttack;
        _enemyData.EnemyAttack.StopAttack += StopAttack;

        InitializeStateMachine();
    }
    private void Update()
    {
        _stateMachine.State.Update();
    }
    private void FixedUpdate()
    {
        _stateMachine.State.FixedUpdate();
    }

    private void StartAttack()
    {
        _stateMachine.State.StartAttack();
    }
    private void StopAttack()
    {
        _stateMachine.State.StopAttack();
    }

    public void SpawnEnemy(Player player)
    {
        _enemyData.EnemyMove.StartSettings(player.transform);
        _stateMachine.ChangeState(typeof(EnemySpawnState));
    }

    private void InitializeStateMachine()
    {
        List<EnemyState> states = new List<EnemyState>()
        {
            new EnemySpawnState(_enemyData),
            new EnemyMoveState(_enemyData),
            new EnemyAttackState(_enemyData),
            new EnemyDeadState(_enemyData)
        };

        _stateMachine = new StateMachine<EnemyState>(states.ToArray());
    }
}
