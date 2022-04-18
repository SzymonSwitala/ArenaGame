using UnityEngine;

public class KingSlimeSpawner : MonoBehaviour
{
    [SerializeField] private KingSlime kingSlimePrefab;
    private bool isSpawned = false;
    private HealthBar bossHealthBar;
    private void Start()
    {

        bossHealthBar = GameManager.Instance.bossHealthBar;
        bossHealthBar.gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSpawned == false)
        {
            isSpawned = true;
            KingSlime kingSlime = Instantiate(kingSlimePrefab, transform);
           
            kingSlime.healthBar = bossHealthBar;
            GameManager.Instance.timer.StartCountDown();
        }

    }


}
