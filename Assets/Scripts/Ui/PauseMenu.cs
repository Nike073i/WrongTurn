using UnityEngine;
using Zenject;

public class PauseMenu : GameProcessMenu
{
    [Inject]
    private void Construct(SceneLoader sceneLoader, RaceManager raceManager)
    {
        _sceneLoader = sceneLoader;
        _raceManager = raceManager;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (_raceManager.CurrentState)
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
        _raceManager.RunGame();
        Close();
    }

    private void PauseGame()
    {
        _raceManager.PauseGame();
        Show();
    }

    public void OnResumeButtonClick()
    {
        ResumeGame();
    }

    public void OnRestartButtonClick()
    {
        _sceneLoader.ReloadLevel();
        Close();
    }

    public void OnMainMenuButtonClick()
    {
        _sceneLoader.LoadMainMenu();
        Close();
    }
}
