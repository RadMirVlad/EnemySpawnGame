using UnityEngine;
public class DieFromFearBehavior : IAggressiveBehavior
{
    private Enemy _enemy;

    public DieFromFearBehavior(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void MakeAggressiveBehavior()
    {
        _enemy.gameObject.SetActive(false);
    }

    public void PrintMessage()
    {
        Debug.Log("Я умер от страха увидев тебя.");
    }
}
