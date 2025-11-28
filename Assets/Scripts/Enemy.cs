using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnemyBehavior _iPeacefulBehavior;
    private IEnemyBehavior _iAggressiveBehavior;

    [SerializeField] private Material _peacefulMaterial;
    [SerializeField] private Material _aggressiveMaterial;

    private Renderer _renderer;

    private bool _isAggressive = false;
    private bool _isSpawned = false;
    private bool _isCharacter = false;

    public void SetBehaviors(IEnemyBehavior iPeacefulBehavior, IEnemyBehavior iAggressiveBehavior, bool startAggressive = false)
    {
        _iPeacefulBehavior = iPeacefulBehavior;
        _iAggressiveBehavior = iAggressiveBehavior;

        _isAggressive = startAggressive;

        InitializeBehavior();
        UpdateMaterial();
    }

    private void InitializeBehavior()
    {
        if (_isSpawned == false)
        {
            if (_isAggressive)
            {
                _iAggressiveBehavior.PrintMessage();
                _iAggressiveBehavior.MakeBehavior();
            }
            else
            {
                _iPeacefulBehavior.PrintMessage();
                _iPeacefulBehavior.MakeBehavior();
            }
            _isSpawned = true;
        }
    }

    private void UpdateMaterial()
    {
        if (_isAggressive)
            _renderer.material = _aggressiveMaterial;
        else
            _renderer.material = _peacefulMaterial;
    }

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        if (_isAggressive)
            _iAggressiveBehavior.MakeBehavior();
        else
            _iPeacefulBehavior.MakeBehavior();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            if (_isCharacter == false)
            {
                _isCharacter = true;
            }
            if (_isAggressive == false)
            {
                _isAggressive = true;

                UpdateMaterial();
                _iAggressiveBehavior.PrintMessage();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            if (_isAggressive)
            {
                _isAggressive = false;

                UpdateMaterial();
                _iPeacefulBehavior.PrintMessage();
            }
        }
    }
}
