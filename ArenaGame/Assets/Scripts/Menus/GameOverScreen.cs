
using UnityEngine;
using UnityEngine.UI;
public class GameOverScreen : Menu
{
    private void OnEnable() => Time.timeScale = 0;

    private void OnDisable() => Time.timeScale = 1;

  
    [SerializeField] private Button backToMainMenuButton;
    [SerializeField] private Button startAgainMenuButton;
    private void Start()
    {
        backToMainMenuButton.onClick.AddListener(() => MenusManager.ChangeScene("MainMenu"));
        startAgainMenuButton.onClick.AddListener(() => MenusManager.ChangeScene("Level1"));
    }
}
