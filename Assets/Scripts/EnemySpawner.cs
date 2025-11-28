using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Transform> _patrolPoints;

    [SerializeField] private Character _character;
    [SerializeField] private EffectsManager _effectsManager;

    private void Awake()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            SpawnAtSpawnPoint(spawnPoint);
        }
    }

    private void SpawnAtSpawnPoint(SpawnPoint spawnPoint)
    {
        if (_enemyPrefab != null)
        {
            Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            Transform transform = enemy.transform;
            Transform targetTransform = _character.transform;
            Mover mover = transform.GetComponent<Mover>(); 
            
            PeacefulBehaviorTypes peacefulBehaviorType = spawnPoint.PeacefulBehaviorTypes;
            AggressiveBehaviorTypes aggressiveBehaviorType = spawnPoint.AggressiveBehaviorTypes;

            IEnemyBehavior peacefulBehavior = MakePeacefulBehavior(peacefulBehaviorType, mover);
            IEnemyBehavior aggressiveBehavior = MakeAggressiveBehavior(aggressiveBehaviorType, transform, targetTransform);

            enemy.SetBehaviors(peacefulBehavior, aggressiveBehavior);
        }
    }

    private IEnemyBehavior MakeAggressiveBehavior(AggressiveBehaviorTypes aggressiveBehaviorType, Transform transform, Transform targetTransform)
    {

        switch (aggressiveBehaviorType)
        {
            case (AggressiveBehaviorTypes.RunAway):
                return new RunAwayBehavior(transform, targetTransform);
            case (AggressiveBehaviorTypes.Chase):
                return new ChaseBehavior(transform, targetTransform);
            case (AggressiveBehaviorTypes.DieFromFear):
                return new DieFromFearBehavior(transform, _effectsManager);

            default:
                return new ChaseBehavior(transform, targetTransform);
        }
    }

    private IEnemyBehavior MakePeacefulBehavior(PeacefulBehaviorTypes peacefulBehaviorType, Mover mover)
    {
        switch (peacefulBehaviorType)
        {
            case (PeacefulBehaviorTypes.DoNothing):
                return new DoNothing();
            case (PeacefulBehaviorTypes.Patrol):
                return new PatrolBehavior(_patrolPoints, mover);
            case (PeacefulBehaviorTypes.Wander):
                return new WanderBehavior(mover);

            default:
                return new PatrolBehavior(_patrolPoints, mover);
        }
    }
}
