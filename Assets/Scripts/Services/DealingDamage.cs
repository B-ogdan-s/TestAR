using UnityEngine;

public class DealingDamage : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EntityHealth health))
        {
            health.SetDamage(_damage);
        }
    }
}
