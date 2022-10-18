using Zenject;

public class FinishMenu : GameProcessMenu
{
    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.OnGameStateUpdated += OnGameStateUpdated;
    }

    private void OnGameStateUpdated(GameState prevState, GameState newState)
    {
        if (newState == GameState.Finished)
            Show();
    }

    public void OnDestroy()
    {
        _gameManager.OnGameStateUpdated -= OnGameStateUpdated;
    }

    public void OnNextLevelButtonClick()
    {
        _gameManager.LoadNextLevel();
        Close();
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
