public class EnemyState : State
{
    protected EnemyComponentData _enemyData;

    public EnemyState(EnemyComponentData enemyData)
    {
        _enemyData = enemyData;
    }

    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void StartMove() { }
    public virtual void StopMove() { }
    public virtual void StartAttack() { }
    public virtual void StopAttack() { }
    public virtual void Dead() { }
}

