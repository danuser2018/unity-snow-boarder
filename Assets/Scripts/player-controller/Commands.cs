using UnityEngine;

public class Command 
{
    public virtual void Execute(Rigidbody2D rigidBody, float torqueAmount) 
    {
    }
}

public class LeftCommand : Command
{
    public override void Execute(Rigidbody2D rigidBody, float torqueAmount)
    {
        rigidBody.AddTorque(torqueAmount);
    }
}


public class RightCommand : Command {
    public override void Execute(Rigidbody2D rigidBody, float torqueAmount)
    {
        rigidBody.AddTorque(-torqueAmount);
    }
}
