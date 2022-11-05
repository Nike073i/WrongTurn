using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FinishMenu : GameProcessMenu
{
    [SerializeField]
    private Button _nextLevelButton;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _mainMenuButton;

    [Inject]
    private void Construct(RaceManager raceManager, SceneLoader sceneLoader)
    {
        _raceManager = raceManager;
        _sceneLoader = sceneLoader;
        _raceManager.OnGameStateUpdated += OnGameStateUpdated;

        AddButtonListeners();
    }

    private void OnDestroy()
    {
        _raceManager.OnGameStateUpdated -= OnGameStateUpdated;
        RemoveButtonListeners();
    }

    private void OnGameStateUpdated(GameState prevState, GameState newState)
    {
        if (newState == GameState.Finished)
            Show();
    }

    private void AddButtonListeners()
    {
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void RemoveButtonListeners()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }

    private void OnNextLevelButtonClick()
    {
        _sceneLoader.LoadNextLevel();
        Close();
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
