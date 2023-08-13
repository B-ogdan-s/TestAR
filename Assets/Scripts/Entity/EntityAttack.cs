using System;
using System.Collections;
using UnityEngine;

public abstract class EntityAttack : MonoBehaviour
{
    [SerializeField, Min(0)] private float _pauseTime;
    [SerializeField] protected Weapon _weapon;

    protected bool _isAttack;
    protected Coroutine _atackCoroutine;

    public Action StartAttack;
    public Action StopAttack;

    protected virtual void OnTriggerEnter(Collider other) { }

    protected virtual void OnTriggerExit(Collider other) { }

    public void Attack()
    {
        if (_atackCoroutine == null)
        {
            _atackCoroutine = StartCoroutine(CR_Attack());
        }
    }

    private IEnumerator CR_Attack()
    {
        Debug.Log(_isAttack);
        while (_isAttack)
        {
            _weapon.Attack();
            yield return new WaitForSecondsRealtime(_pauseTime);
        }
    }
}
