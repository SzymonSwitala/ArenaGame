using UnityEngine;
[RequireComponent(typeof(Movement))]
public class Player: MonoBehaviour
{
    private Movement movement;
     [SerializeField] private Aim aim;
    [SerializeField] private ShootingController shootingController;

    private void Start()
    {
        movement = GetComponent<Movement>();
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
  
}
