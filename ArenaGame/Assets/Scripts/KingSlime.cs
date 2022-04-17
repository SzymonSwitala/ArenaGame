using System.Collections;
using UnityEngine;

public class KingSlime : MonoBehaviour
{
    [SerializeField] Slime slime;
    private void Start()
    {
        InvokeRepeating("SpawnSlimes",1,100);
    }


   
    void SpawnSlimes()
    {
        for (int i = 0; i < 3; i++)
        {
            Slime newSlime = Instantiate(slime, transform.position, Quaternion.identity);
            newSlime.StartMove();
        }
    }
}
