
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

    [SerializeField] private TextMeshProUGUI timerText;
    private void Start()
    {
        timer.StartCountDown();
   

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        timerText.text = timer.GetTimeInClockFormat();
    }
}
