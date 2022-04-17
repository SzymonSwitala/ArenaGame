
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject hitEffect;
    

   
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
        if (collision.tag=="Player")
        {
            return;
        }
        Instantiate(hitEffect,transform.position,transform.rotation);
        DisableProjectile();
    }

}
