public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyComponentData enemyData) : base(enemyData)
    {
    }

    public override void Enter()
    {
        _enemyData.EnemyAttack.Attack();
    }

    public override void StopAttack()
    {
        ChangeState?.Invoke(typeof(EnemyMoveState));
    }
}

