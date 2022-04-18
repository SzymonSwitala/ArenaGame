using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

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
    public Timer timer;
    public Player player;
    public HealthBar bossHealthBar;
    public GameObject endScreen;
    [SerializeField] private TextMeshProUGUI timerText;
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        timerText.text = timer.GetTimeInClockFormat();
    }
}
