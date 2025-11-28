using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffectPrefab;
    private float _offsetValue = 1f;
    private float _timeToDestroy = 2f;

    public void PlayDeathEffect(Vector3 position)
    {
        Vector3 offsetY = new Vector3(0, _offsetValue, 0);
        ParticleSystem deathEffect = Instantiate(_deathEffectPrefab, position + offsetY, Quaternion.identity, transform);
        deathEffect.Play();

        Destroy(deathEffect.gameObject, _timeToDestroy);
    }
}
