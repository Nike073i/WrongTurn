using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseMenu : GameProcessMenu
{
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _mainMenuButton;

    [Inject]
    private void Construct(SceneLoader sceneLoader, RaceManager raceManager)
    {
        _sceneLoader = sceneLoader;
        _raceManager = raceManager;

        AddButtonListeners();
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

    private void OnDestroy()
    {
        RemoveButtonListeners();
    }

    private void AddButtonListeners()
    {
        _resumeButton.onClick.AddListener(OnResumeButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void RemoveButtonListeners()
    {
        _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
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

    private void OnResumeButtonClick()
    {
        ResumeGame();
    }

    private void OnRestartButtonClick()
    {
        _sceneLoader.ReloadLevel();
        Close();
    }

    private void OnMainMenuButtonClick()
    {
        _sceneLoader.LoadMainMenu();
        Close();
    }
}
