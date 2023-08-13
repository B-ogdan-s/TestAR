using UnityEngine;

public class EnemySpawnState : EnemyState
{
    public EnemySpawnState(EnemyComponentData enemyData) : base(enemyData)
    {
    }

    public override void Enter()
    {
        ChangeState?.Invoke(typeof(EnemyMoveState));
    }

    public override void StartAttack()
    {
        ChangeState?.Invoke(typeof(EnemyAttackState));
    }

}