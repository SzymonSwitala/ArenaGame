using System.Collections;
using UnityEngine;

public class KingSlime : Enemy
{
    [SerializeField] Slime slime;
    private Transform target;
    [SerializeField] private Transform slimeSprites;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private FlashEffect[] flashEffect;
    protected override void Start()
    {
        base.Start();
        target = GameManager.Instance.player.transform;
        healthBar.SetBar(healthPoints);
      
       // InvokeRepeating("SpawnSlimes", 1, 100);
    }
    public override void GetDamage(int value)
    {
        base.GetDamage(value);
        healthBar.UpdateBar(healthSystem.GetHealth());
        flashEffect[0].Flash();
        flashEffect[1].Flash();
    }
    private void Update()
    {
        if (transform.position.x - target.position.x > 0)
        {
            slimeSprites.transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            slimeSprites.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void SpawnSlimes()
    {
        for (int i = 0; i < 3; i++)
        {
            Slime newSlime = Instantiate(slime, transform.position, Quaternion.identity);
          
        }
    }
}
