using UnityEngine;
using UnityEngine.UI;

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
    public GameSceneLoader GameSceneLoader;

    [Header("Set Dynamically")]
    private int _selectedItemIndex = -1;

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
            InvokeCommand(_selectedItemIndex);
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

    private void InvokeCommand(int menuIndex)
    {
        if (menuIndex < 0 || menuIndex >= MenuItems.Length)
        {
            return;
        }
        MenuItem curItem = MenuItems[menuIndex];
        if (!string.IsNullOrEmpty(curItem.Command))
        {
            GameSceneLoader.Invoke(curItem.Command, 0f);
        }
    }

    private void SelectPrevMenuItem()
    {
        SelectMenuItem(GetPrevItemIndex());
    }
    private void SelectNextMenuItem()
    {
        SelectMenuItem(GetNextItemIndex());
    }
}
