using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _parents;
    [SerializeField] private Player _player;

    private PoolObject<Enemy> _poolEnemy;
    private Coroutine _crSpawnEnemyTymer;

    private void Awake()
    {
        _poolEnemy = new PoolObject<Enemy>(_enemyPrefab, _parents);
    }

    private IEnumerator SpawnEnemyTymer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            Enemy enemy = _poolEnemy.GetObject();

            enemy.transform.localPosition = new Vector3(Random.Range(-1.5f, 1.5f), 0.2f, Random.Range(-1.5f, 1.5f));
        }

    }

    public void OnTargetFound()
    {
        _crSpawnEnemyTymer = StartCoroutine(SpawnEnemyTymer());
    }
    public void OnTargetLost()
    {
        StopCoroutine(_crSpawnEnemyTymer);
        _poolEnemy.DisableAll();
    }
}
