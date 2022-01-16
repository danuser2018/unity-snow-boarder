using Zenject;

public class InputManager
{
    private CommandHandler leftHandler;
    private CommandHandler rightHandler;

    // Start is called before the first frame update
    [Inject]
    public InputManager(LeftCommandHandler leftHandler, RightCommandHandler rightHandler)
    {
        this.leftHandler = leftHandler;
        this.rightHandler = rightHandler;
    }

    public void Process(Command command) {
        if (isLeft(command)) manageLeft(command);
        else if (isRight(command)) manageRight(command);
    }

    private bool isLeft(Command command) {
        return command is LeftCommand;
    }

    private bool isRight(Command command) {
        return command is RightCommand;
    }

    private void manageLeft(Command command) {
        leftHandler.Execute(command.gameObject, command.torqueAmount);
    }

    private void manageRight(Command command) {
        rightHandler.Execute(command.gameObject, command.torqueAmount);
    }
}
