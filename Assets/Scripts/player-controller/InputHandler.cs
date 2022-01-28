using UnityEngine;
using Zenject;

public class InputHandler
{
    private readonly Command commandLeft;
    private readonly Command commandRight;
    private readonly Command defaultCommand;

    [Inject]
    public InputHandler(Command commandLeft, Command commandRight, Command defaultCommand)
    {
        this.commandLeft = commandLeft;
        this.commandRight = commandRight;
        this.defaultCommand = defaultCommand;
    }

    public Command GetCommand()
    {
        Command command;
        if (IsLeft()) command = commandLeft;
        else if (IsRight()) command = commandRight;
        else command = defaultCommand;

        return command;
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
