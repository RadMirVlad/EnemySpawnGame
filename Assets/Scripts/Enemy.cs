using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private IPeacefulBehavior _iPeacefulBehavior;
    private IAggressiveBehavior _iAggressiveBehavior;

    private bool _isAggressive = false;
    private bool _isSpawned = false;
    private bool _isCharacter = false;
    public void SetBehaviors(IPeacefulBehavior iPeacefulBehavior, IAggressiveBehavior iAggressiveBehavior, bool startAggressive = false)
    {
        _iPeacefulBehavior = iPeacefulBehavior;
        _iAggressiveBehavior = iAggressiveBehavior;
        _isAggressive = startAggressive;

        InitializeBehavior();
    }

    private void InitializeBehavior()
    {
        if (_isSpawned == false)
        {
            if (_isAggressive)
            {
                _iAggressiveBehavior.PrintMessage();
                _iAggressiveBehavior.MakeAggressiveBehavior();
            }
            else
            {
                _iPeacefulBehavior.PrintMessage();
                _iPeacefulBehavior.MakePeacefulBehavior();
            }
            _isSpawned = true;
        }
    }

    private void Update()
    {
        if (_isAggressive)
            _iAggressiveBehavior.MakeAggressiveBehavior();
        else
            _iPeacefulBehavior.MakePeacefulBehavior();
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
                _iPeacefulBehavior.PrintMessage();
            }
        }
    }
}
