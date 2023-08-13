using UnityEngine;

public class LineSetting : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField, Min(4)] private int _size;
    [SerializeField, Min(0.1f)] private float _radius;

    private void Awake()
    {
        _lineRenderer.positionCount = _size;
        SetPosition();
    }

    private void SetPosition()
    {
        float addAngle = 360f / _size;
        float angle = 0;

        for (int i = 0; i < _size; i++)
        {
            float newAngle = angle / 180f * Mathf.PI;

            Vector3 newPos = new Vector3(Mathf.Sin(newAngle), 0, Mathf.Cos(newAngle)) * _radius;
            _lineRenderer.SetPosition(i, newPos);

            Debug.Log($"{i}) a: {angle / 180f * Mathf.PI}; pos: {newPos / 180f * Mathf.PI};");

            angle += addAngle;
        }
    }
}
