using UnityEngine;
using Zenject;

public class LevelKeybordController : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameManager.Running)
            {
                if (!_gameManager.Paused)
                {
                    Cursor.visible = true;
                    _gameManager.PauseGame();
                    return;
                }
                if (_gameManager.Paused)
                {
                    Cursor.visible = false;
                    _gameManager.ContinueGame();
                }
            }
        }
    }
}
