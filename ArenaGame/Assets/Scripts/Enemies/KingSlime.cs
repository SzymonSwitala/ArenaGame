using UnityEngine;
using System.Collections;
public class KingSlime : Enemy
{

    private Transform target;
    public HealthBar healthBar;
    [SerializeField] private Transform slimeSprites;
    [SerializeField] private FlashEffect[] flashEffect;
    [SerializeField] private GameObject slimeballPrefab;
    public Animator animator;
    public BossFightController bossFightController;
   
    protected override void Start()
    {
        base.Start();

        target = GameManager.Instance.player.transform;
        healthBar.SetBar(healthPoints);
        StartCoroutine(Behaviour());

    }

    IEnumerator Behaviour()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Falling"))
        {
            yield return new WaitForEndOfFrame();
        }
        GameManager.Instance.bossHealthBar.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Shoot(0);
        yield return new WaitForSeconds(2);
        Shoot(30);
        yield return new WaitForSeconds(1); 
        Shoot(45);
        yield return new WaitForSeconds(1);
        animator.SetBool("Jump", true);
        bossFightController.SpawnSlimes();
        yield return new WaitForSeconds(6);
        transform.position = GameManager.Instance.player.transform.position;
        yield return new WaitForSeconds(1);
        animator.SetBool("Jump", false);
        StartCoroutine(Behaviour());
        yield return null;


    }
    public override void GetDamage(int value)
    {
        base.GetDamage(value);
        healthBar.UpdateBar(healthSystem.GetHealth());
        flashEffect[0].Flash();
        flashEffect[1].Flash();
        if (healthSystem.GetHealth() <= 0)
        {
            GameManager.Instance.timer.StopCountDown();
            GameManager.Instance.bossHealthBar.gameObject.SetActive(false);
        }
    }
    public override void Dead()
    {
        GameManager.Instance.endScreen.SetActive(true);
        base.Start();

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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.GetDamage(1);
            StartCoroutine(player.Knockback(1, 25, gameObject));

        }
    }
    private void Shoot(int angle)
    {
        int amount = 6;
        float spreadAngle = 60f;



        for (int i = 0; i < amount; i++)
        {


            Instantiate(slimeballPrefab, transform.position, Quaternion.Euler(0, 0, (i * spreadAngle) - angle));

        }

    }


}
