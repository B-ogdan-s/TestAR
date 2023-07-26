using UnityEngine;

public class JoystickUI : MonoBehaviour
{
    [SerializeField] private InputJoystickTouche _inputJoystickTouche;
    [SerializeField] private Transform _joystickBackground;
    [SerializeField] private Transform _joystickButton;


    private Vector3 _startPosJoystickBackground;

    private void Awake()
    {
        _startPosJoystickBackground = _joystickBackground.position;

        _inputJoystickTouche.OnUpdateDirection += UpdateUI;
        _inputJoystickTouche.OnPointerDownAction += SetPosJoystickBackground;
        _inputJoystickTouche.OnPointerUpAction += RestartPos;
    }

    private void UpdateUI(Vector2 direction)
    {
        _joystickButton.localPosition = direction * _inputJoystickTouche.MaxRadius;
    }

    private void SetPosJoystickBackground(Vector2 newPos)
    {
        _joystickBackground.position = newPos;
    }
    private void RestartPos()
    {
        _joystickBackground.position = _startPosJoystickBackground;
        _joystickButton.localPosition = Vector3.zero;
    }
}
