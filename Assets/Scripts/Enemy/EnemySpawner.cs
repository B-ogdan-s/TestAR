using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _parents;
    [SerializeField] private Player _player;
    [SerializeField, Min(1)] private float _timePause;
    [SerializeField] private float _spawnRadius;

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
            yield return new WaitForSecondsRealtime(_timePause);
            Enemy enemy = _poolEnemy.GetObject();
            enemy.SpawnEnemy(_player);

            float angle = Random.Range(0f, 360f) / 180f * Mathf.PI;
            Vector3 newPos = new (Mathf.Sin(angle), 0, Mathf.Cos(angle));

            enemy.transform.localPosition = newPos * _spawnRadius;
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
