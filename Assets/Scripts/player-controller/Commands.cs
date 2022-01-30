using UnityEngine;

public interface Command 
{
    public void Execute(Rigidbody2D rigidBody, float torqueAmount);
}

public class DefaultCommand : Command
{
    public void Execute(Rigidbody2D rigidBody, float torqueAmount)
    {
    }
}


public class LeftCommand : Command
{
    public void Execute(Rigidbody2D rigidBody, float torqueAmount)
    {
        rigidBody.AddTorque(torqueAmount);
    }
}


public class RightCommand : Command {
    public void Execute(Rigidbody2D rigidBody, float torqueAmount)
    {
        rigidBody.AddTorque(-torqueAmount);
    }
}
