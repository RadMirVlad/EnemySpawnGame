using UnityEngine;

public class Mover : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField] private float _moveSpeed;

    private float _currentMoveSpeed;
    private float _startMoveSpeed;
    public float MoveSpeed => _moveSpeed;

    public Mover(float moveSpeed)
    {
        _currentMoveSpeed = moveSpeed;
    }
    private void Awake()
    {
        _startMoveSpeed = MoveSpeed;
        _characterController = GetComponent<CharacterController>();
        ResetMoveSpeed();
    }

    public void ProcessMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _currentMoveSpeed * Time.deltaTime);
    }

    public void IncreaseMoveSpeed(float moveSpeedBoost)
    {
        _currentMoveSpeed += moveSpeedBoost;
        _moveSpeed = _currentMoveSpeed;
    }

    public void ResetMoveSpeed()
    {
        _currentMoveSpeed = _startMoveSpeed;
        _moveSpeed = _currentMoveSpeed;
    }
}
