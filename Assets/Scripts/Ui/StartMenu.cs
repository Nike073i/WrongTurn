using Zenject;

public class StartMenu : GameProcessMenu
{
    [Inject]
    private void Construct(RaceManager raceManager, SceneLoader sceneLoader)
    {
        _raceManager = raceManager;
        _sceneLoader = sceneLoader;
        _raceManager.OnGameStateUpdated += OnGameStateUpdated;
        if (_raceManager.CurrentState == GameState.Pregame)
            Show();
    }

    private void OnGameStateUpdated(GameState prevState, GameState newState)
    {
        if (newState == GameState.Pregame)
            Show();
    }

    public void OnDestroy()
    {
        _raceManager.OnGameStateUpdated -= OnGameStateUpdated;
    }

    public void OnStartButtonClick()
    {
        _raceManager.RunGame();
        Close();
    }

    public void OnMainMenuButtonClick()
    {
        _sceneLoader.LoadMainMenu();
        Close();
    }
}
