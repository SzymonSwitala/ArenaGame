using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlime : MonoBehaviour
{
    [SerializeField] private GameObject slimeballPrefab;
    [SerializeField] private GameObject slimePrefab;
    private Transform player;
    private HealthSystem healthSystem;
    [SerializeField] private Transform[] jumpPositions;
  
    private void Start()
    {
        player = GameManager.Instance.player.transform;
        healthSystem = new HealthSystem(50);
        GameManager.Instance.bossHealthBar.SetBar(healthSystem.GetHealth());
    }
    public void Shoot(int angle)
    {
        int amount = 6;
        float spreadAngle = 60f;

        for (int i = 0; i < amount; i++)
        {
            Instantiate(slimeballPrefab, transform.position, Quaternion.Euler(0, 0, (i * spreadAngle) - angle));
        }
    }
    public Vector2 GetRandomJumpPosition()
    {
        int randomIndex = Random.Range(0,jumpPositions.Length);
        Transform randomPos = jumpPositions[randomIndex];
        return randomPos.position;
    }
   public void SpawnSlimes()
    {
       Slime slime= Instantiate(slimePrefab,transform.position,Quaternion.identity).GetComponent<Slime>();
        slime.StartFollowTarget();
    }
    private void LookAtPlayer()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
           transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void GetDamage(int value)
    {
        healthSystem.Damage(value);
        GameManager.Instance.bossHealthBar.UpdateBar(healthSystem.GetHealth());
        if (healthSystem.GetHealth() <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {

    }
}
