using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
  
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
