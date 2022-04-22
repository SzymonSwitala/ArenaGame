using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour, IDamagable
{
    private HealthSystem healthSystem;
    private Movement movement;
    private Rigidbody2D rb;
    private FlashEffect flashEffect;
    [SerializeField] private Aim aim;
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private int healthPoints = 3;
    [SerializeField] private HeartsSystem heartsSystem;

    private void Start()
    {
        healthSystem = new HealthSystem(healthPoints);
        heartsSystem.Refresh(healthPoints);
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        flashEffect = GetComponent<FlashEffect>(); 
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
      //  flashEffect.Flash();
        heartsSystem.Refresh(healthPoints);
        if (healthSystem.GetHealth() <= 0)
        {
            Dead();

        }
    }
    private void Dead()
    {
        gameObject.SetActive(false);

        Invoke("ShowEndScreen", 3);


    }
    private void ShowEndScreen()
    {
       // GameManager.Instance.endScreen.SetActive(true);
    }
    public IEnumerator Knockback(float duration, float power, GameObject obj)
    {
        float timer = 0;
        while (duration > timer)
        {
            
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * power, ForceMode2D.Force);

        }

        yield return null;
    }
}
