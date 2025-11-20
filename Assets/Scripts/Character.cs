using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterMover _characterMover;
    private CharacterRotator _characterRotator;

    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    private int _currentHealth;
    private int _startHealth;

    private Vector3 _normalizedInput;

    [SerializeField] private int _health;
    public float DeadZone { get; } = 0.1f;
    public int Health => _health;

    private void Awake()
    {
        _characterMover = GetComponent<CharacterMover>();
        _characterRotator = GetComponent<CharacterRotator>();

        _startHealth = _currentHealth = Health; 
    }
    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(_horizontalAxis), 0, Input.GetAxisRaw(_verticalAxis));

        if (input.magnitude < DeadZone)
            return;

        _normalizedInput = input.normalized;

        _characterMover.ProcessMoveTo(_normalizedInput);
        _characterRotator.ProcessRotateTo(_normalizedInput);
    }

    public void IncreaseHealth(int healthBoost)
    {
        _currentHealth += healthBoost;
        _health = _currentHealth;
    }

    public void ResetHealth()
    {
        _currentHealth = _startHealth;
        _health = _currentHealth;
    }
}
