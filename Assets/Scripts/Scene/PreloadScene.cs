using UnityEngine;
using Zenject;

public class PreloadScene : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Start()
    {
        Invoke(nameof(LoadMainMenu), 3f);
    }

    private void LoadMainMenu()
    {
        _sceneLoader.LoadMainMenu();
    }
}
