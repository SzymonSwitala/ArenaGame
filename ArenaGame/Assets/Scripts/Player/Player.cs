using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour, IDamagable
{
    private HealthSystem healthSystem;
    private Movement movement;
    [SerializeField] private Aim aim;
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private int healthPoints = 3;
    FlashEffect flashEffect;
    [SerializeField] private HeartsSystem heartsSystem;
    Rigidbody2D rigidbody2D;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        healthSystem = new HealthSystem(healthPoints);
        flashEffect = GetComponent<FlashEffect>();
        heartsSystem.Refresh(healthPoints);
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            aim.AimTarget(mousePosition);
            shootingController.Shoot();
        }

    }
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.Move(direction);

    }
    public void GetDamage(int value)
    {

        healthSystem.Damage(value);
        healthPoints = healthSystem.GetHealth();
        flashEffect.Flash();
        heartsSystem.Refresh(healthPoints);

    }
    public IEnumerator Knockback(float duration,float power,GameObject obj)
    {
        float timer = 0;
        while (duration>timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rigidbody2D.AddForce(-direction*power,ForceMode2D.Force);

        }

        yield return null;
    }
}
