using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusFreeMovementZone;

    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _rotDirection = Vector3.zero;
    private float _speedValue = 0;

    public void SetMoveDirection(Vector2 direction)
    {
        _speedValue = direction.magnitude;
        _moveDirection = new Vector3(direction.x, 0, direction.y);
    }
    public void Move()
    {
        Vector3 step = _moveDirection * _speed * _speedValue * Time.fixedDeltaTime;

        if(CheckFreeMovementZone(step))
            transform.Translate(step, Space.World);
    }

    public void SetRotateDirection(Vector2 direction)
    {
        _rotDirection = new Vector3(direction.x, 0, direction.y);
    }
    public void Rotate()
    {
        transform.localRotation = Quaternion.LookRotation(_rotDirection);
    }

    private bool CheckFreeMovementZone(Vector3 step)
    {
        Vector3 newPos = transform.localPosition + step;

        float distans = newPos.magnitude;

        if (distans >= _radiusFreeMovementZone)
            return false;

        return true;
    }

    public void RemoveSpeedValue()
    {
        _speedValue = 0;
    }
}
