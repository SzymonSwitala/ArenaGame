using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI logoText;
    [SerializeField] private TextMeshProUGUI versionText;
    private void Start()
    {
        Version();
        StartCoroutine(TypeText("Arena Game", logoText,4));
       
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Version()
    {
        versionText.text=Application.version;
    }
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
}
