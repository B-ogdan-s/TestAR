using UnityEngine;

public class EnemyAttack : EntityAttack
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _isAttack = true;
            StartAttack?.Invoke();
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _isAttack = false;
            StopAttack?.Invoke();

            if (_atackCoroutine != null)
            {
                StopCoroutine(_atackCoroutine);
                _atackCoroutine = null;
            }
        }
    }
}

