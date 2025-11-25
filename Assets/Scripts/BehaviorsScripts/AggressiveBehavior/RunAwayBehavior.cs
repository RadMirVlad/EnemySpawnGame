using UnityEngine;
using UnityEngine.TextCore.Text;

public class RunAwayBehavior : IAggressiveBehavior
{
    private Enemy _enemy;
    private Character _character;
    private Mover _mover;

    public RunAwayBehavior(Enemy enemy, Character character)
    {
        _enemy = enemy;
        _character = character;

        _mover = _enemy.GetComponent<Mover>();
    }

    public void MakeAggressiveBehavior()
    {
        Vector3 direction = GetDirectionToCharacter();

        Vector3 normalizedDirection = direction.normalized;
        _mover.ProcessMoveTo(-normalizedDirection);
    }

    public void PrintMessage()
    {
        Debug.Log("Я убегаю от тебя.");
    }

    private Vector3 GetDirectionToCharacter() => _character.transform.position - _enemy.transform.position;
}
