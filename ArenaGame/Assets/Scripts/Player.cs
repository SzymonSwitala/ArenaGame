using UnityEngine;
[RequireComponent(typeof(Movement))]
public class Player: MonoBehaviour
{
    private Movement movement;
    // [SerializeField] private Aim aim;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.Move(direction);

    }
  
}
