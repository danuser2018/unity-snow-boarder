using Zenject;

public interface PlayerInputService
{
    public PlayerMovementCommand GetMovementCommand();
}

public class PlayerInputServiceImpl : PlayerInputService
{
    [Inject (Id = "left")] private readonly PlayerMovementCommand leftCommand;
    [Inject (Id = "right")] private readonly PlayerMovementCommand rightCommand;
    [Inject (Id = "default")] private readonly PlayerMovementCommand defaultCommand;
    [Inject] private readonly InputHandler inputHandler;

    public PlayerMovementCommand GetMovementCommand()
    {
        if (inputHandler.IsKeyLeftPressed()) return leftCommand;
        else if (inputHandler.IsKeyRightPressed()) return rightCommand;
        else return defaultCommand;
    }
}