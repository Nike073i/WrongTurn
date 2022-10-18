using UnityEngine;
using Zenject;

public class PauseMenu : GameProcessMenu
{
    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (_gameManager.CurrentState)
            {
                case GameState.Paused:
                    ResumeGame();
                    break;
                case GameState.Running:
                    PauseGame();
                    break;
            }
        }
    }

    private void ResumeGame()
    {
        _gameManager.RunGame();
        Close();
    }

    private void PauseGame()
    {
        _gameManager.PauseGame();
        Show();
    }

    public void OnResumeButtonClick()
    {
        ResumeGame();
    }

    public void OnRestartButtonClick()
    {
        _gameManager.ReloadLevel();
        Close();
    }

    public void OnMainMenuButtonClick()
    {
        _gameManager.LoadMainMenu();
        Close();
    }
}
