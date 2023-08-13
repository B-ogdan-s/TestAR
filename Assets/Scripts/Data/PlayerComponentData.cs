using UnityEngine;

[System.Serializable]
public class PlayerComponentData
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private InputJoystickTouche _joystickTouche;
    [SerializeField] private EntityHealth _entityHealth;
    [SerializeField] private EntityAttack _entityAttack;
    public PlayerMove PlayerMove => _playerMove;
    public InputJoystickTouche JoystickTouche => _joystickTouche;
    public EntityHealth EntityHealth => _entityHealth;
    public EntityAttack EntityAttack => _entityAttack;
}