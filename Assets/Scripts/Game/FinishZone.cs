using UnityEngine;
using Zenject;

public class FinishZone : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.FinishGame();
    }
}
