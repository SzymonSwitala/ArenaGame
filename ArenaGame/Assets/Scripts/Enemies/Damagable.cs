using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour, IDamagable
{
    [System.Serializable]
    public class CustomEvent : UnityEvent<int>
    {

    }

    public CustomEvent customEvent;
    
    public void GetDamage(int value)
    {
        customEvent.Invoke(value);

    }
}
