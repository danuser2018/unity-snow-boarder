using UnityEngine;

public class InputHandlerAdapter : InputHandler
{
    public bool IsKeyLeftPressed() 
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool IsKeyRightPressed()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
}
