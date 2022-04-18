using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsSystem : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;

    [SerializeField] List<GameObject> hearts;
    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject heart = Instantiate(heartPrefab, transform);
            hearts.Add(heart);
        }
        heartPrefab.SetActive(false);
    }
 
  
    public void Refresh(int health)
    {
        for (int i = health; i < hearts.Count; i++)
        {
            hearts[i].SetActive(false);
        }
    }
}
