using UnityEngine;
using UnityEngine.UIElements;

public class DoNothing : IEnemyBehavior
{
    public DoNothing() { }
    public void MakeBehavior() { }

    public void PrintMessage()
    {
        Debug.Log("Я стою и ничего не делаю, даже не дышу");
    }
}
