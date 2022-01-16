using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {
    public readonly GameObject gameObject;
    public readonly float torqueAmount;

    protected Command(GameObject gameObject, float torqueAmount) {
        this.gameObject = gameObject;
        this.torqueAmount = torqueAmount;
    }
}

public class LeftCommand : Command {
    public LeftCommand(GameObject gameObject, float torqueAmount) 
        : base(gameObject, torqueAmount) {}
}

public class RightCommand : Command {
    public RightCommand(GameObject gameObject, float torqueAmount) 
        : base(gameObject, torqueAmount) {}
}
