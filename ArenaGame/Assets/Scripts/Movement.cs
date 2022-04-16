using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]


public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }
  
    public void Move(Vector2 direction)
    {

        if (Mathf.Abs(direction.x) > 0.01f || Mathf.Abs(direction.y) > 0.01f)
        {
          
                animator.SetBool("isRunning", true);
            
          

        }
        else
        {
            animator.SetBool("isRunning", false);

        }

        if (direction.x < 0)
        {
            //  transform.localScale = new Vector3(-1, 1, 1);
            if (spriteRenderer!=null)
            {
                spriteRenderer.flipX = true;
            }
        

        }
        if (direction.x > 0)
        {
            // transform.localScale = new Vector3(1, 1, 1);
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = false;
            }
        

        }

        rb.MovePosition((Vector2)transform.position + direction * Time.fixedDeltaTime * speed);
    }


}
