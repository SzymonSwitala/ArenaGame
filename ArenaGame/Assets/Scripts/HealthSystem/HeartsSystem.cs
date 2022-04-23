using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsSystem : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;

    [SerializeField] List<GameObject> hearts;
    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject heart = Instantiate(heartPrefab, transform);
            hearts.Add(heart);
            heart.SetActive(false);
        }
        heartPrefab.SetActive(false);
    }


    public void Refresh(int health)
    {
        for (int i=0; i<10;i++)
        {
         
            if (i<health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }


        }
    }
}
