using System.Collections;
using UnityEngine;
using DG.Tweening;
public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private Slime slime;
    [SerializeField] private GameObject shadow;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
   
       
    
    IEnumerator Spawn()
    {
        Slime newSlime = Instantiate(slime, new Vector3(transform.position.x, transform.position.y + 30, transform.position.z), Quaternion.identity);
        float fallTime = 2;
        newSlime.transform.DOMove(transform.position, fallTime);
        shadow.SetActive(true);
        yield return new WaitForSeconds(fallTime);
        shadow.SetActive(false);
        newSlime.StartMove();
    }

}
