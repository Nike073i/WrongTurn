using Zenject;

public class StartMenu : GameProcessMenu
{
    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.OnGameStateUpdated += OnGameStateUpdated;
        if (_gameManager.CurrentState == GameState.Pregame)
            Show();
    }

    private void OnGameStateUpdated(GameState prevState, GameState newState)
    {
        if (newState == GameState.Pregame)
            Show();
    }

    public void OnDestroy()
    {
        _gameManager.OnGameStateUpdated -= OnGameStateUpdated;
    }

    public void OnStartButtonClick()
    {
        _gameManager.RunGame();
        Close();
    }

    public void OnMainMenuButtonClick()
    {
        _gameManager.LoadMainMenu();
        Close();
    }
}
