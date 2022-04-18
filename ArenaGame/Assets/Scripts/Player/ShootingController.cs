using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform firePoint;
    [SerializeField] float cooldown;
    private float timer;

    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        if (timer < cooldown)
        {
            
            timer += Time.deltaTime;
        }
  
    }
    public void Shoot()
    {
        if (timer < cooldown) return;
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        timer = 0;
    }
}
