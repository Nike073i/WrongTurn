using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    private PauseService _pauseService;

    public float ElapsedTime { get; private set; }
    public GameState CurrentState { get; private set; } = GameState.Pregame;
    public Action<GameState, GameState> OnGameStateUpdated;
    public int CurrentLevel { get; private set; }
    public Action<int> OnGameLevelChanged;

    [Inject]
    private void Construct(SceneLoader sceneLoader, PauseService pauseService)
    {
        _sceneLoader = sceneLoader;
        _pauseService = pauseService;
    }

    public void LoadCityLevel()
    {
        UpdateGameLevel(SceneLoader.LastLevelIndex);
    }

    public void LoadSandLevel()
    {
        UpdateGameLevel(SceneLoader.LastLevelIndex);
    }

    public void LoadMainMenu()
    {
        UpdateGameLevel(SceneLoader.MainMenuSceneIndex);
    }

    public void StartGame()
    {
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

    public void ResumeGame()
    {
        UpdateGameState(GameState.Running);
    }

    public void MainMenu()
    {
        _sceneLoader.LoadMainMenu();
    }

    public void UpdateGameState(GameState newState)
    {
        var prevState = CurrentState;
        CurrentState = newState;
        switch (newState)
        {
            case GameState.Pregame:
                HandlePregameState();
                break;
            case GameState.Running:
                HandleRunningState();
                break;
            case GameState.Paused:
                HandlePauseState();
                break;
            case GameState.Finished:
                HandleFinishedState();
                break;
        }
        OnGameStateUpdated?.Invoke(prevState, newState);
    }

    public void UpdateGameLevel(int levelIndex)
    {
        _sceneLoader.LoadScene(levelIndex);
        CurrentLevel = levelIndex;
        UpdateGameState(GameState.Pregame);
        OnGameLevelChanged?.Invoke(levelIndex);
    }

    private void HandleRunningState()
    {
        Cursor.visible = false;
        _pauseService.Resume();
    }

    private void HandleFinishedState()
    {
        Cursor.visible = true;
        _pauseService.SetPause();
    }

    private void HandlePauseState()
    {
        Cursor.visible = true;
        _pauseService.SetPause();
    }

    private void HandlePregameState()
    {
        Cursor.visible = true;
        _pauseService.SetPause();
        ElapsedTime = 0;
    }
}
