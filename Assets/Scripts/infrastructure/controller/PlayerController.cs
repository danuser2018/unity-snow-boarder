using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    [Inject] private readonly PlayerInputService playerInputService;

    void Update()
    {
        playerInputService.GetMovementCommand().Move(torqueAmount);
    }
}
