using UnityEngine;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public MenuItem[] _menuItems;

    private int _selectedItemIndex = -1;

    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Start()
    {
        SelectMenuItem(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectNextMenuItem();
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectPrevMenuItem();
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Invoke(_menuItems[_selectedItemIndex].CommandName, 0f);
            return;
        }
    }

    private void SelectMenuItem(int menuItemIndex)
    {
        if (menuItemIndex < 0 || menuItemIndex >= _menuItems.Length)
            return;

        if (_selectedItemIndex > -1)
        {
            MenuItem curItem = _menuItems[_selectedItemIndex];
            curItem.ButtonImage.sprite = curItem.SpriteGeneral;
        }
        _selectedItemIndex = menuItemIndex;
        MenuItem newItem = _menuItems[_selectedItemIndex];
        newItem.ButtonImage.sprite = newItem.SpriteHover;
    }

    private int GetNextItemIndex()
    {
        return _selectedItemIndex + 1 < _menuItems.Length ? _selectedItemIndex + 1 : 0;
    }

    private int GetPrevItemIndex()
    {
        return _selectedItemIndex - 1 >= 0 ? _selectedItemIndex - 1 : _menuItems.Length - 1;
    }

    private void SelectPrevMenuItem()
    {
        SelectMenuItem(GetPrevItemIndex());
    }
    private void SelectNextMenuItem()
    {
        SelectMenuItem(GetNextItemIndex());
    }

    private void StartGame()
    {
        _gameManager.LoadSandLevel();
    }

    private void ExitGame()
    {
        _gameManager.ExitGame();
    }
}
