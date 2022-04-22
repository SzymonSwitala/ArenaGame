using System.Collections;
using UnityEngine;
using DG.Tweening;
public class Slime : Enemy
{
    private Transform target;
    [SerializeField] private HealthBar healthBar;

    protected override void Start()
    {
        base.Start();
        target = GameManager.Instance.player.transform;  
        healthBar.SetMaxHealth(healthSystem.GetHealth());
        healthBar.gameObject.SetActive(false);
    }
 
    public void StartFollowTarget()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        float randomTimeBetweenJump = Random.Range(1, 3);
        yield return new WaitForSeconds(randomTimeBetweenJump);
        Jump();
        StartCoroutine(Move());
    }
    void Jump()
    {
        Vector2 direction;
        direction = target.position - this.transform.position;
        direction.Normalize();
        direction *= new Vector2(2, 2);
        Vector2 jumpPosition = (Vector2)transform.position + direction;
        if (Vector2.Distance(transform.position,target.position)>2)
        {
            transform.DOJump(jumpPosition, 1, 1, 1);
        }
        else
        {
            transform.DOJump(target.position, 1, 1, 1);
        }
       

        
    }
    public override void GetDamage(int value)
    {
        base.GetDamage(value);
        healthBar.SetHealth(healthSystem.GetHealth());
        healthBar.gameObject.SetActive(true);

    }
    public override void Dead()
    {
        transform.DOPause();
        base.Dead();
        transform.DOPause();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.GetDamage(1);
            StartCoroutine(player.Knockback(1, 25, gameObject));
            transform.DOPause();
        }
    }
  
}
