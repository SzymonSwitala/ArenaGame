using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
 
    public void AimTarget(Vector2 target)
    {
        Vector2 targetDir = (target - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1);
       
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
          
        }
    }


}
