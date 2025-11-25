using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private List<Transform> _patrolPoints;

    [SerializeField] private Character _character;

    private void Awake()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            SpawnAtSpawnPoint(spawnPoint, _character);
        }
    }
    private void SpawnAtSpawnPoint(SpawnPoint spawnPoint, Character character)
    {
        if (_enemyPrefab != null)
        {
            Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            PeacefulBehaviorTypes peacefulBehaviorType = spawnPoint.PeacefulBehaviorTypes;
            AggressiveBehaviorTypes aggressiveBehaviorType = spawnPoint.AggressiveBehaviorTypes;

            IPeacefulBehavior peacefulBehavior = MakePeacefulBehavior(peacefulBehaviorType, enemy);
            IAggressiveBehavior aggressiveBehavior = MakeAggressiveBehavior(aggressiveBehaviorType, enemy, character);

            enemy.SetBehaviors(peacefulBehavior, aggressiveBehavior);
        }
    }

    private IAggressiveBehavior MakeAggressiveBehavior(AggressiveBehaviorTypes aggressiveBehaviorType, Enemy enemy, Character character)
    {
        switch (aggressiveBehaviorType)
        {
            case (AggressiveBehaviorTypes.RunAway):
                return new RunAwayBehavior(enemy, character);
            case (AggressiveBehaviorTypes.Chase):
                return new ChaseBehavior(enemy, character);
            case (AggressiveBehaviorTypes.DieFromFear):
                return new DieFromFearBehavior(enemy);

            default:
                return new ChaseBehavior(enemy, character);
        }
    }

    private IPeacefulBehavior MakePeacefulBehavior(PeacefulBehaviorTypes peacefulBehaviorType, Enemy enemy)
    {
        switch (peacefulBehaviorType)
        {
            case (PeacefulBehaviorTypes.DoNothing):
                return new DoNothing();
            case (PeacefulBehaviorTypes.Patrol):
                return new PatrolBehavior(_patrolPoints, enemy);
            case (PeacefulBehaviorTypes.Wander):
                return new WanderBehavior(_patrolPoints, enemy);

            default:
                return new PatrolBehavior(_patrolPoints, enemy);
        }
    }
}
