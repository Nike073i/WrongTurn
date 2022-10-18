using UnityEngine;

public abstract class GameProcessMenu : MonoBehaviour
{
    [SerializeField]
    protected GameObject _menuUi;

    protected GameManager _gameManager;

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
