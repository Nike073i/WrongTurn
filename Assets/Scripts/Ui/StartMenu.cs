using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartMenu : GameProcessMenu
{
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _mainMenuButton;

    [Inject]
    private void Construct(RaceManager raceManager, SceneLoader sceneLoader)
    {
        _raceManager = raceManager;
        _sceneLoader = sceneLoader;

        AddButtonListeners();

        _raceManager.OnGameStateUpdated += OnGameStateUpdated;
        if (_raceManager.CurrentState == GameState.Pregame)
            Show();
    }

    private void OnDestroy()
    {
        _raceManager.OnGameStateUpdated -= OnGameStateUpdated;
        RemoveButtonListeners();
    }

    private void AddButtonListeners()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void RemoveButtonListeners()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }

    private void OnGameStateUpdated(GameState prevState, GameState newState)
    {
        if (newState == GameState.Pregame)
            Show();
    }

    private void OnStartButtonClick()
    {
        _raceManager.RunGame();
        Close();
    }

    private void OnMainMenuButtonClick()
    {
        _sceneLoader.LoadMainMenu();
        Close();
    }
}
