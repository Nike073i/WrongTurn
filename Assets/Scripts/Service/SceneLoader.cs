using System;
using UnityEngine.SceneManagement;

public enum Scene
{
    Preload,
    MainMenu,
    SandLevel,
    CityLevel
}

public class SceneLoader
{
    public Scene CurrentScene { get; private set; }
    public Action<Scene> OnGameLevelChanged;

    public void ReloadLevel()
    {
        UpdateGameLevel(CurrentScene);
    }

    public void LoadCityLevel()
    {
        UpdateGameLevel(Scene.CityLevel);
    }

    public void LoadSandLevel()
    {
        UpdateGameLevel(Scene.SandLevel);
    }

    public void LoadMainMenu()
    {
        UpdateGameLevel(Scene.MainMenu);
    }

    public void LoadNextLevel()
    {
        if (CurrentScene == Scene.CityLevel)
            UpdateGameLevel(Scene.SandLevel);
        else
            UpdateGameLevel(Scene.CityLevel);
    }

    public void UpdateGameLevel(Scene scene)
    {
        LoadScene(scene);
        CurrentScene = scene;
        OnGameLevelChanged?.Invoke(scene);
    }

    private void LoadScene(Scene scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}
