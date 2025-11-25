using System.Collections.Generic;
using UnityEngine;
public class WanderBehavior : IPeacefulBehavior
{
    private float _minDistanceToTarget = 0.05f;

    private Enemy _enemy;
    private Mover _mover;

    private Vector3 _currentTarget;

    private List<Transform> _patrolPoints;

    public WanderBehavior(List<Transform> patrolPoints, Enemy enemy)
    {
        _patrolPoints = patrolPoints;
        _enemy = enemy;
        _mover = _enemy.GetComponent<Mover>();

        SwitchTarget();
    }

    public void MakePeacefulBehavior()
    {
        Vector3 direction = _currentTarget - _enemy.transform.position;

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
        Debug.Log("Я брожу туда-сюда от точки до точки в случайном порядке.");
    }

    private void SwitchTarget()
    {
        int randomIndex = Random.Range(0, _patrolPoints.Count);
        _currentTarget = _patrolPoints[randomIndex].position;
    }
}
