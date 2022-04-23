using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class MenusManager : MonoBehaviour
{
    private static MenusManager s_instance;
    private Menu currentMenu;
    [SerializeField] private Menu[] menus;
    [SerializeField] private Menu startMenu;
    private Stack<Menu> history = new Stack<Menu>();

    public static void ChangeMenu<T>(bool saveToHistory) where T : Menu
    {
        for (int i = 0; i < s_instance.menus.Length; i++)
        {
            if (s_instance.menus[i] is T)
            {
                if (s_instance.currentMenu != null)
                {
                    if (saveToHistory)
                    {
                        s_instance.history.Push(s_instance.currentMenu);
                    }
                  
                    s_instance.currentMenu.Hide();

                }
                s_instance.menus[i].Show();
                s_instance.currentMenu = s_instance.menus[i];
            }

        }
    }
    public static void ChangeMenu(Menu menu, bool saveToHistory)
    {
        if (s_instance.currentMenu != null)
        {
            if (saveToHistory)
            {
                s_instance.history.Push(s_instance.currentMenu);
            }
          
            s_instance.currentMenu.Hide();
          
        }
        menu.Show();
        s_instance.currentMenu = menu;
    }
    public static void ShowLastMenu()
    {
        if (s_instance.history.Count != 0)
        {
            ChangeMenu(s_instance.history.Pop(),false);
        }
    }
    public static Menu GetCurrentMenu()
    {

        return s_instance.currentMenu;
    }
    public static T GetMenu<T>() where T : Menu
    {
        for (int i = 0; i < s_instance.menus.Length; i++)
        {
            if (s_instance.menus[i] is T menu)
            {
                return menu;
            }

        }
        return null;
    }
  
    private void Awake() => s_instance = this;
    private void Start()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].Hide();

            if (startMenu != null)
            {
                ChangeMenu(startMenu,true);
            }
        }
    }

    //Buttons 
    public static void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static void ChangeScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}
