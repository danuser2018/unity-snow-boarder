using Zenject;

public interface PlayerMovementCommand
{
    public void Move(float torqueAmount);
}

public class PlayerDefaultMovementCommand : PlayerMovementCommand
{
    public void Move(float torqueAmount)
    {
    }
}

public class PlayerLeftMovementCommand : PlayerMovementCommand 
{
    [Inject] private readonly PlayerHandler playerHandler;

    public void Move(float torqueAmount) 
    {
        playerHandler.AddTorque(torqueAmount);
    }
}

public class PlayerRightMovementCommand : PlayerMovementCommand
{
    [Inject] private readonly PlayerHandler playerHandler;

    public void Move(float torqueAmount) 
    {
        playerHandler.AddTorque(-torqueAmount);
    }
}
