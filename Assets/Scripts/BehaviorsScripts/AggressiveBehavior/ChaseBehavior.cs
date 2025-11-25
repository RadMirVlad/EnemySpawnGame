using UnityEngine;
public class ChaseBehavior : IAggressiveBehavior
{
    private Enemy _enemy;
    private Character _character;
    private Mover _mover;

    public ChaseBehavior(Enemy enemy, Character character)
    {
        _enemy = enemy;
        _character = character;

        _mover = _enemy.GetComponent<Mover>();
    }

    public void MakeAggressiveBehavior()
    {
        Vector3 direction = GetDirectionToCharacter();

        Vector3 normalizedDirection = direction.normalized;
        _mover.ProcessMoveTo(normalizedDirection);
    }

    public void PrintMessage()
    {
        Debug.Log("Я иду к тебе чтобы потрогать.");
    }

    private Vector3 GetDirectionToCharacter() => _character.transform.position - _enemy.transform.position;
}
