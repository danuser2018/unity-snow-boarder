using UnityEngine;
using Zenject;

public class InputHandler
{
    [Inject (Id = "left")]
    private readonly Command commandLeft;
    [Inject (Id = "right")]
    private readonly Command commandRight;
    [Inject (Id = "default")]
    private readonly Command defaultCommand;

    public Command GetCommand()
    {
        if (IsLeft()) return commandLeft;
        else if (IsRight()) return commandRight;
        else return defaultCommand;
    }

    private bool IsLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    private bool IsRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
}

interface 
