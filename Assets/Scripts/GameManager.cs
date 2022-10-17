using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    public float ElapsedTime { get; private set; }
    public GameState CurrentState { get; private set; } = GameState.Pregame;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    public void StartGame()
    {
        ElapsedTime = 0;
        UpdateGameState(GameState.Running);
    }

    public void FinishGame()
    {
        UpdateGameState(GameState.Finished);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (CurrentState == GameState.Running)
        {
            ElapsedTime += Time.deltaTime;
        }
    }

    public void PauseGame()
    {
        UpdateGameState(GameState.Paused);
    }

    public void ContinueGame()
    {
        UpdateGameState(GameState.Running);
    }

    public void MainMenu()
    {
        _sceneLoader.LoadMainMenu();
    }

    public void UpdateGameState(GameState newState)
    {
        CurrentState = newState;
    }

}
