using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

        }
        else
        {
            instance = this;
        }
    }
   
    public Player player;

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (MenusManager.GetCurrentMenu()==MenusManager.GetMenu<PauseMenu>())
            {    
                MenusManager.ChangeMenu<GameUI>(true);
            }
            else
            { 
                MenusManager.ChangeMenu<PauseMenu>(true);
            }
          
           
        }
    }



}
