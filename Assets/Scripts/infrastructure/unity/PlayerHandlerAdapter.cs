using UnityEngine;

public class PlayerHandlerAdapter : PlayerHandler
{
    public void AddTorque(float torqueAmount)
    {
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddTorque(torqueAmount * Time.deltaTime);
    }
}
