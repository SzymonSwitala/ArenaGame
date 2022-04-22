using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour
{
    private static MenusManager s_instance;
    [SerializeField] private Menu[] menus;
    private Menu currentMenu;
    [SerializeField] private Menu startMenu;

    public static void ChangeMenu<T>() where T : Menu
    {
        for (int i=0;i<s_instance.menus.Length;i++)
        {
            if (s_instance.menus[i] is T)
            {
                if (s_instance.currentMenu != null)
                {
                    s_instance.currentMenu.Hide();

                }
                s_instance.menus[i].Show();
                s_instance.currentMenu = s_instance.menus[i];
            }
         
        }
    }
    public static void ChangeMenu(Menu menu)
    {
        if (s_instance.currentMenu != null)
        {
            s_instance.currentMenu.Hide();
        }
        menu.Show();
        s_instance.currentMenu = menu;
    }
    private void Awake() => s_instance = this;
    private void Start()
    {
        for (int i=0;i<menus.Length;i++)
        {
            menus[i].Hide();

            if (startMenu != null)
            {
                ChangeMenu(startMenu);
            }
        }
    }

    //Buttons 
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
