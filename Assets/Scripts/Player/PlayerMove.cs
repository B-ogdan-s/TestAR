using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusFreeMovementZone;

    private Vector3 _direction = Vector3.zero;
    private float _speedValue = 0;

    public void Move()
    {
        Vector3 step = transform.forward * _speed * _speedValue * Time.fixedDeltaTime;

        if(CheckFreeMovementZone(step))
            transform.Translate(step, Space.World);
    }
    public void SetDirection(Vector2 direction)
    {
        _speedValue = direction.magnitude;
        _direction = new Vector3(direction.x, 0, direction.y);
        Rotate();
    }
    public void RemoveSpeedValue()
    {
        _speedValue = 0;
    }

    private void Rotate()
    {
        transform.localRotation = Quaternion.LookRotation(_direction);
    }

    private bool CheckFreeMovementZone(Vector3 step)
    {
        Vector3 newPos = transform.localPosition + step;

        float distans = newPos.magnitude;

        if (distans >= _radiusFreeMovementZone)
            return false;

        return true;
    }
}
