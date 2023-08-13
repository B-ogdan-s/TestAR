using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _bodyTransform;

    private Transform _playerTarget;

    public void StartSettings(Transform playerTarget)
    {
        _playerTarget = playerTarget;
    }

    public void Move()
    {
        Vector3 direction = (_playerTarget.localPosition - transform.localPosition).normalized;

        transform.Translate(direction * Time.deltaTime * _speed);
        _bodyTransform.localRotation = Quaternion.LookRotation(direction);
    }
}
