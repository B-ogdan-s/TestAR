using UnityEngine;

[System.Serializable]
public class PlayerComponentData
{
    [SerializeField] private PlayerMove _playerMove;
    public PlayerMove PlayerMove => _playerMove;
}