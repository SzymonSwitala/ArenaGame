using System.Collections;
using UnityEngine;
using DG.Tweening;
public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private Slime slime;
    [SerializeField] private GameObject shadow;


    public void Spawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        Slime newSlime = Instantiate(slime, new Vector3(transform.position.x, transform.position.y + 30, transform.position.z), Quaternion.identity);
        float fallTime = 2;
        newSlime.GetComponent<Collider2D>().enabled = false;
        newSlime.transform.DOMove(transform.position, fallTime);
        shadow.SetActive(true);
        yield return new WaitForSeconds(fallTime);
        newSlime.GetComponent<Collider2D>().enabled =true;
        shadow.SetActive(false);
        newSlime.StartFollowTarget();

    }

}
