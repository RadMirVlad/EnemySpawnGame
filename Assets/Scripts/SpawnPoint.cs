using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private PeacefulBehaviorTypes _peacefulBehaviorTypes;
    [SerializeField] private AggressiveBehaviorTypes _aggressiveBehaviorTypes;

    public PeacefulBehaviorTypes PeacefulBehaviorTypes => _peacefulBehaviorTypes;
    public AggressiveBehaviorTypes AggressiveBehaviorTypes => _aggressiveBehaviorTypes;
}
