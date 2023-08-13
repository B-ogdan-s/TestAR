using UnityEngine;

public class EnemyMoveState : EnemyState
{

    public EnemyMoveState(EnemyComponentData enemyData):base(enemyData)
    {
        _enemyData = enemyData;
    }

    public override void FixedUpdate()
    {
        _enemyData.EnemyMove.Move();
    }
    public override void StartAttack()
    {
        ChangeState?.Invoke(typeof(EnemyAttackState));
    }
}
