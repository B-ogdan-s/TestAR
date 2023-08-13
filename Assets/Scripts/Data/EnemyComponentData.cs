using System;
using UnityEngine;

[Serializable]
public class EnemyComponentData
{
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private EntityAttack _enemyAttack;
    [SerializeField] private EntityHealth _health;

    public EnemyMove EnemyMove => _enemyMove;
    public EntityAttack EnemyAttack => _enemyAttack;
    public EntityHealth Health => _health;
}

