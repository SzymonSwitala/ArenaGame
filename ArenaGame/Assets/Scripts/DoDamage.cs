using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.GetDamage(damage);
        }
        if (collision.tag == "Player")
        {

            StartCoroutine(collision.GetComponent<Player>().Knockback(1, 25, gameObject));
        }
    }
}
