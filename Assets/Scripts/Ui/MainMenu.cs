using Assets.Scripts.Game;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private MenuItem _startGameMenuItem;
    [SerializeField]
    private MenuItem _exitGameMenuItem;
    [SerializeField]
    private Button _downButton;
    [SerializeField]
    private Button _upButton;

    private List<MenuItem> _menuItems;
    private int _selectedItemIndex;

    private GameManager _gameManager;
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(GameManager gameManager, SceneLoader sceneLoader)
    {
        _gameManager = gameManager;
        _sceneLoader = sceneLoader;

        AddButtonListeners();
        InitializeMenuItemList();
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
            _menuItems[_selectedItemIndex].Button.onClick.Invoke();
            return;
        }
    }

    private void OnDestroy()
    {
        RemoveButtonListeners();
    }

    private void InitializeMenuItemList()
    {
        _menuItems = new List<MenuItem>
        {
            _startGameMenuItem,
            _exitGameMenuItem
        };
        SelectMenuItem(0);
    }

    private void AddButtonListeners()
    {
        _startGameMenuItem.Button.onClick.AddListener(OnStartGameButtonClick);
        _exitGameMenuItem.Button.onClick.AddListener(OnExitGameButtonClick);
        _downButton.onClick.AddListener(OnDownButtonClick);
        _upButton.onClick.AddListener(OnUpButtonClick);
    }

    private void RemoveButtonListeners()
    {
        _startGameMenuItem.Button.onClick.RemoveListener(OnStartGameButtonClick);
        _exitGameMenuItem.Button.onClick.RemoveListener(OnExitGameButtonClick);
        _downButton.onClick.RemoveListener(OnDownButtonClick);
        _upButton.onClick.RemoveListener(OnUpButtonClick);
    }

    private void OnStartGameButtonClick()
    {
        StartGame();
    }
    private void OnExitGameButtonClick()
    {
        ExitGame();
    }

    private void OnDownButtonClick()
    {
        SelectPrevMenuItem();
    }
    private void OnUpButtonClick()
    {
        SelectNextMenuItem();
    }

    private void SelectMenuItem(int menuItemIndex)
    {
        if (menuItemIndex < 0 || menuItemIndex >= _menuItems.Count)
            return;

        if (_selectedItemIndex > -1)
        {
            var currentMenuItem = _menuItems[_selectedItemIndex];
            currentMenuItem.Button.image.sprite = currentMenuItem.SpriteGeneral;
        }
        _selectedItemIndex = menuItemIndex;
        var newItem = _menuItems[_selectedItemIndex];
        newItem.Button.image.sprite = newItem.SpriteHover;
    }

    private int GetNextItemIndex()
    {
        return _selectedItemIndex + 1 < _menuItems.Count ? _selectedItemIndex + 1 : 0;
    }

    private int GetPrevItemIndex()
    {
        return _selectedItemIndex - 1 >= 0 ? _selectedItemIndex - 1 : _menuItems.Count - 1;
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
        _sceneLoader.LoadSandLevel();
    }

    private void ExitGame()
    {
        _gameManager.ExitGame();
    }
}
