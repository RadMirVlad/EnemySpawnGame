using UnityEngine;

public class RunAwayBehavior : IEnemyBehavior
{
    private Transform _transform;
    private Transform _targetTransform;
    private Mover _mover;

    public RunAwayBehavior(Transform transform, Transform targetTransform)
    {
        _transform = transform;

        _targetTransform = targetTransform;

        _mover = _transform.GetComponent<Mover>();
    }

    public void MakeBehavior()
    {
        Vector3 direction = GetDirectionToCharacter();

        Vector3 normalizedDirection = direction.normalized;
        _mover.ProcessMoveTo(-normalizedDirection);
    }

    public void PrintMessage()
    {
        Debug.Log("Я убегаю от тебя.");
    }

    private Vector3 GetDirectionToCharacter() => _targetTransform.position - _transform.position;
}
