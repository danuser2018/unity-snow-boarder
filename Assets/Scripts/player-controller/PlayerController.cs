using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    [Inject] InputManager inputManager;

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
