using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputJoystickTouche : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private uint _maxRadius;

    private Vector2 _startTouch;

    public uint MaxRadius => _maxRadius;

    public Action<Vector2> OnPointerDownAction;
    public Action OnStartMove;

    public Action OnPointerUpAction;
    public Action OnStopMove;

    public Action<Vector2> OnUpdateDirection;
    

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _startTouch;

        if(direction.magnitude > _maxRadius)
        {
            OnUpdateDirection(direction.normalized);
            return;
        }

        direction /= _maxRadius;
        OnUpdateDirection(direction);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startTouch = eventData.position;
        OnPointerDownAction?.Invoke(eventData.position);
        OnStartMove?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerUpAction?.Invoke();
        OnStopMove?.Invoke();
    }
}
