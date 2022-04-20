
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int damage;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnEnable()
    {
        Invoke("DisableProjectile", 30);
    }
    private void DisableProjectile()
    {

        Destroy(gameObject);
    }
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.GetDamage(damage);
        }

        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, transform.rotation);

        }
        if (collision.tag=="Player")
        {
         
            StartCoroutine(collision.GetComponent<Player>().Knockback(1, 25, gameObject));
        }
        DisableProjectile();

    }

}
