using UnityEngine;

public class ChaseBehavior : IEnemyBehavior
{
    private Transform _transform;
    private Transform _targetTransform;
    private Mover _mover;

    public ChaseBehavior(Transform transform, Transform targetTransform)
    {
        _transform = transform;
        _targetTransform = targetTransform;

        _mover = _transform.GetComponent<Mover>();
    }

    public void MakeBehavior()
    {
        Vector3 direction = GetDirectionToCharacter();

        Vector3 normalizedDirection = direction.normalized;
        _mover.ProcessMoveTo(normalizedDirection);
    }

    public void PrintMessage()
    {
        Debug.Log("Я иду к тебе чтобы потрогать.");
    }

    private Vector3 GetDirectionToCharacter() => _targetTransform.position - _transform.transform.position;
}
