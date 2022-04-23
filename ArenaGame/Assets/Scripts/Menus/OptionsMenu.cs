using UnityEngine;
using UnityEngine.UI;
public class OptionsMenu : Menu
{
    private void OnEnable() => Time.timeScale = 0;

    private void OnDisable() => Time.timeScale = 1;

    [SerializeField] private Button backButton;
    private void Start()
    {
        backButton.onClick.AddListener(() => MenusManager.ShowLastMenu());
    }
}
