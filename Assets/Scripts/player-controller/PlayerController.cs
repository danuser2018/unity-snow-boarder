using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    InputManager inputManager;

    void Start()
    {
        inputManager = new InputManager();
    }

    void Update()
    {
        if (isLeft()) manageLeft();
        else if (isRight()) manageRight();
    }

    private bool isLeft() {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    private bool isRight() {
        return Input.GetKey(KeyCode.RightArrow);
    }

    private void manageLeft() {
        inputManager.Process(new LeftCommand(this.gameObject, torqueAmount));
    }

    private void manageRight() {
        inputManager.Process(new RightCommand(this.gameObject, torqueAmount));
    }
}
