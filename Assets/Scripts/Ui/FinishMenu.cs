using Zenject;

public class FinishMenu : GameProcessMenu
{
    [Inject]
    private void Construct(RaceManager raceManager, SceneLoader sceneLoader)
    {
        _raceManager = raceManager;
        _sceneLoader = sceneLoader;
        _raceManager.OnGameStateUpdated += OnGameStateUpdated;
    }

    private void OnGameStateUpdated(GameState prevState, GameState newState)
    {
        if (newState == GameState.Finished)
            Show();
    }

    public void OnDestroy()
    {
        _raceManager.OnGameStateUpdated -= OnGameStateUpdated;
    }

    public void OnNextLevelButtonClick()
    {
        _sceneLoader.LoadNextLevel();
        Close();
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
