using UnityEngine;
using UnityEngine.UI;
using Zenject;

[System.Serializable]
public class MenuItem
{
    public Sprite SpriteGeneral;
    public Sprite SpriteHover;
    public GameObject ButtonObject;
    public string Command;
    [System.NonSerialized]
    public Image ButtonImage;
}

public class Menu : MonoBehaviour
{
    [Header("Set in Inspector")]
    public MenuItem[] MenuItems;

    private GameManager _gameManager;
    private int _selectedItemIndex = -1;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void Start()
    {
        Cursor.visible = true;
        foreach (MenuItem menuItem in MenuItems)
        {
            menuItem.ButtonImage = menuItem.ButtonObject.GetComponent<Image>();
        }
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
            Invoke(MenuItems[_selectedItemIndex].Command, 0f);
            return;
        }
    }

    private void SelectMenuItem(int menuItemIndex)
    {
        if (menuItemIndex < 0 || menuItemIndex >= MenuItems.Length)
        {
            return;
        }

        if (_selectedItemIndex > -1)
        {
            MenuItem curItem = MenuItems[_selectedItemIndex];
            curItem.ButtonImage.sprite = curItem.SpriteGeneral;
        }
        _selectedItemIndex = menuItemIndex;
        MenuItem newItem = MenuItems[_selectedItemIndex];
        newItem.ButtonImage.sprite = newItem.SpriteHover;
    }

    private int GetNextItemIndex()
    {
        return _selectedItemIndex + 1 < MenuItems.Length ? _selectedItemIndex + 1 : 0;
    }

    private int GetPrevItemIndex()
    {
        return _selectedItemIndex - 1 >= 0 ? _selectedItemIndex - 1 : MenuItems.Length - 1;
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
        _gameManager.LoadCityLevel();
    }

    private void ExitGame()
    {
        _gameManager.ExitGame();
    }
}
