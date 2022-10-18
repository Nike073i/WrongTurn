using UnityEngine;
using Zenject;

public class PreloadScene : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Start()
    {
        Invoke(nameof(LoadMainMenu), 3f);
    }

    private void LoadMainMenu()
    {
        _gameManager.LoadMainMenu();
    }
}
