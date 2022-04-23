using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button backToMainMenuButton;
    [SerializeField] private Button optionsButton;
    private void Start()
    {
        backButton.onClick.AddListener(() => MenusManager.ShowLastMenu());
        backToMainMenuButton.onClick.AddListener(() => MenusManager.ChangeScene("MainMenu"));
        optionsButton.onClick.AddListener(() => MenusManager.ChangeMenu<OptionsMenu>(true));
    }
    private void OnEnable() => Time.timeScale = 0;

    private void OnDisable() => Time.timeScale = 1;
}
