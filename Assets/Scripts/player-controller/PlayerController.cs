using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject] InputHandler inputHandler;
    private Rigidbody2D rigidBody;
    [SerializeField] private float torqueAmount;

    private void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputHandler.GetCommand().Execute(rigidBody, torqueAmount * Time.deltaTime);
    }
}
