using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Slider slider;
   
    public void SetBar(int health)
    {
     
        slider.maxValue = health;
        slider.value = health;
     
    }
    public void UpdateBar(int health)
    {
        slider.value = health;

    } 
}
