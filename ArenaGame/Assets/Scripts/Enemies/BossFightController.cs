using UnityEngine;
using System.Collections;
public class BossFightController : MonoBehaviour
{
    [SerializeField] private KingSlime kingSlimePrefab;
    private bool isSpawned = false;
    private HealthBar bossHealthBar;
    [SerializeField] private SlimeSpawner[] slimeSpawners;
    private void Start()
    {

        bossHealthBar = GameManager.Instance.bossHealthBar;
        bossHealthBar.gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSpawned == false)
        {
            if (collision.tag == "Player")
            {
                isSpawned = true;
                KingSlime kingSlime = Instantiate(kingSlimePrefab, transform);
                kingSlime.bossFightController = this;
                kingSlime.healthBar = bossHealthBar;
                GameManager.Instance.timer.StartCountDown();
              

            }
        }

    }

    public void  SpawnSlimes()
    {
        foreach (SlimeSpawner slimeSpawner in slimeSpawners)
        {
            slimeSpawner.Spawn();
        }

      
   
    }
}
