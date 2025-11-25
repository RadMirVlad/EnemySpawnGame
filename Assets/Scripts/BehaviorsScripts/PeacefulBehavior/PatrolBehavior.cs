using System.Collections.Generic;
using UnityEngine;
public class PatrolBehavior : IPeacefulBehavior
{
    private float _minDistanceToTarget = 0.05f;

    private Enemy _enemy;
    private Mover _mover;

    private Vector3 _currentTarget;

    private List<Transform> _patrolPoints;

    private Queue<Vector3> _queuePatrolPoints;

    public PatrolBehavior(List<Transform> patrolPoints, Enemy enemy)
    {
        _patrolPoints = patrolPoints;
        _enemy = enemy;
        _mover = _enemy.GetComponent<Mover>();

        CreateQueue();
    }

    public void MakePeacefulBehavior()
    {
        Vector3 targetPosition = _currentTarget;
        Vector3 direction = targetPosition - _enemy.transform.position;

        if (direction.magnitude <= _minDistanceToTarget)
        {
            SwitchTarget();
            direction = _currentTarget - _enemy.transform.position;
        }

        Vector3 normalizedDirection = direction.normalized;
        _mover.ProcessMoveTo(normalizedDirection);
    }

    public void PrintMessage()
    {
        Debug.Log("—мотри как € патрулирую по заданному пор€дку точек.");
    }

    private void SwitchTarget()
    {
        if(_queuePatrolPoints.Count > 0)
        {
            _currentTarget = _queuePatrolPoints.Dequeue();
            _queuePatrolPoints.Enqueue(_currentTarget);
        }
    }

    private void CreateQueue()
    {
        _queuePatrolPoints = new Queue<Vector3>(_patrolPoints.Count);

        foreach (Transform patrolPoint in _patrolPoints)
        {
            _queuePatrolPoints.Enqueue(patrolPoint.position);
        }

        if(_queuePatrolPoints.Count > 0)
            _currentTarget = _queuePatrolPoints.Peek();
    }
}
