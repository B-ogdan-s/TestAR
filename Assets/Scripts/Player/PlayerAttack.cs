using UnityEngine;

public class PlayerAttack : EntityAttack
{
    [SerializeField] private uint _countEnemy = 0;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _countEnemy++;
            _isAttack = true;
            StartAttack?.Invoke();
        }

    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _countEnemy--;
            if(_countEnemy <= 0)
            {
                _countEnemy = 0;
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
}

