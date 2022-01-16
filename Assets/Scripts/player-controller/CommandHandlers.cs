using UnityEngine;

public interface CommandHandler
{
    public void Execute(GameObject gameObject, float torqueAmount);
}

public class LeftCommandHandler : CommandHandler
{
    public void Execute(GameObject gameObject, float torqueAmount) {
        gameObject.GetComponent<Rigidbody2D>().AddTorque(torqueAmount);
    }
}

public class RightCommandHandler : CommandHandler
{
    public void Execute(GameObject gameObject, float torqueAmount) {
        gameObject.GetComponent<Rigidbody2D>().AddTorque(-torqueAmount);
    }
}
