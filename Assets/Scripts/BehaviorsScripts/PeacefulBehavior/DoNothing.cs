using UnityEngine;
public class DoNothing : IPeacefulBehavior
{
    public void MakePeacefulBehavior()
    {
        
    }

    public void PrintMessage()
    {
        Debug.Log("Я стою и ничего не делаю, даже не дышу");
    }
}
