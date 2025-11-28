using UnityEngine;
using UnityEngine.UIElements;

public class WanderBehavior : IEnemyBehavior
{
    private float _timeToChangeDirection = 1f;
    private float _currentTime = 0;
    private int valueToRandom = 10;

    private Vector3 _currentDirection;

    private Mover _mover;
    private Material _material;

    public WanderBehavior(Mover mover)
    {
        _mover = mover;

        SwitchTarget();
    }

    public void MakeBehavior()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeToChangeDirection)
        {
            SwitchTarget();
            _currentTime = 0;
        }

        Vector3 direction = _currentDirection;
        Vector3 normalizedDirection = direction.normalized;

        _mover.ProcessMoveTo(normalizedDirection);
    }

    public void PrintMessage()
    {
        Debug.Log("Я брожу туда-сюда.");
    }

    private void SwitchTarget()
    {
        int randomX = Random.Range(-valueToRandom, valueToRandom);
        int randomZ = Random.Range(-valueToRandom, valueToRandom);

        if (randomX != 0 && randomZ != 0)
            _currentDirection = new(randomX, 0, randomZ);
        else
            _currentDirection = Vector3.left;
    }
}
