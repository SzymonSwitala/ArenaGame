using System.Collections;
using UnityEngine;
using DG.Tweening;
public class Slime : Enemy
{
    private Transform target;
 

    public void StartMove()
    {
        target = GameManager.Instance.player.transform;
        
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
  
}
