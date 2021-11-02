using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private MenuController MenuController;
    void Awake()
    {
        if (!SceneManager.GetSceneByName("Menus").isLoaded)
        {
            SceneManager.LoadScene("Menus", LoadSceneMode.Additive);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Menus", LoadSceneMode.Additive);
    }

    public void LevelSelect()
    {
        FindMenuController().OpenMenu(Menu.LEVEL_SELECT);
    }

    private MenuController FindMenuController()
    {
        if (MenuController == null)
        {
            MenuController = FindObjectOfType<MenuController>();
        }
        return MenuController;
    }
}