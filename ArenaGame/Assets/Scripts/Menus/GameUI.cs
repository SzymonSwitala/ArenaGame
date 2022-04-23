using UnityEngine;
using TMPro;
public class GameUI : Menu
{
    public HealthBar bossHealthBar;
    public HeartsSystem heartsSystem;
    public Timer timer;

    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        timerText.text = timer.GetTimeInClockFormat();
    }

}
