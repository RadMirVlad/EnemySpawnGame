using System.Collections.Generic;
using UnityEngine;
public class DieFromFearBehavior : IEnemyBehavior
{
    private Transform _transform;
    private EffectsManager _effectsManager;

    public DieFromFearBehavior(Transform transform, EffectsManager effectsManager)
    {
        _transform = transform;
        _effectsManager = effectsManager;
    }
    public void MakeBehavior()
    {
        _transform.gameObject.SetActive(false);
        _effectsManager.PlayDeathEffect(_transform.position);
    }

    public void PrintMessage()
    {
        Debug.Log("Я умер от страха увидев тебя.");
    }
}
