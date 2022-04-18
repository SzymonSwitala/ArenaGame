using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GetDamage : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject idamagableGameObject;
    IDamagable iDamagable;
    void Start()
    {
        iDamagable = idamagableGameObject.GetComponent<IDamagable>();
    }
    void IDamagable.GetDamage(int value)
    {
        if (iDamagable==null)
        {
            Debug.LogWarning("iDamagable interface didn't attach");
            return;
        }
        iDamagable.GetDamage(value);
    }



}
