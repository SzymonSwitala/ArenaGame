
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

    [SerializeField] private TextMeshProUGUI timerText;
    private void Start()
    {
        timer.StartCountDown();
   

    }
    private void Update()
    {

        timerText.text = timer.GetTimeInClockFormat();
    }
}
