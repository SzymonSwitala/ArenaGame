using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainMenu : Menu
{
    [SerializeField] private TextMeshProUGUI versionText;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        Version();
        optionsButton.onClick.AddListener(() => MenusManager.ChangeMenu<OptionsMenu>(true));
        startButton.onClick.AddListener(() => MenusManager.ChangeScene("Level1"));
        quitButton.onClick.AddListener(() => MenusManager.QuitGame());
    }
    public void Version()
    {
        versionText.text = Application.version;
    }

}


/*
IEnumerator TypeText(string textToType,TextMeshProUGUI textMeshProUGUI,float speed)
{
    int charIndex=0;
    float timer = 0;

    while (charIndex<textToType.Length)
    {
        timer += Time.deltaTime*speed;
        charIndex = Mathf.FloorToInt(timer);
        charIndex = Mathf.Clamp(charIndex,0,textToType.Length);
        textMeshProUGUI.text = textToType.Substring(0,charIndex);
        yield return null;
    }
}
*/

