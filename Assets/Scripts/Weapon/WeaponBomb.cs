using UnityEngine;
using DG.Tweening;
using System.Collections;

public class WeaponBomb : Weapon
{
    [SerializeField] private float _attackTime;
    [SerializeField] private float _attackSize;
    [SerializeField] private Transform _bombTransform;
    
    private void OnEnable()
    {
        _bombTransform.localScale = Vector3.zero;
    }

    public override void Attack()
    {
        StartCoroutine(CR_Attack());
    }

    private IEnumerator CR_Attack()
    {
        Debug.Log("Boom");
        _bombTransform.DOScale(Vector3.one * _attackSize, _attackTime).SetEase(Ease.OutCirc);
        yield return new WaitForSecondsRealtime(_attackTime);
        _bombTransform.localScale = Vector3.zero;
    }
}
