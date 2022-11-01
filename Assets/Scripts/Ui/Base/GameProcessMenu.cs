using UnityEngine;

public abstract class GameProcessMenu : MonoBehaviour
{
    [SerializeField]
    protected GameObject _menuUi;

    protected RaceManager _raceManager;
    protected SceneLoader _sceneLoader;

    protected void Show()
    {
        Cursor.visible = true;
        _menuUi.SetActive(true);
    }

    protected void Close()
    {
        Cursor.visible = false;
        _menuUi.SetActive(false);
    }
}
