using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    [SerializeField]private Slider slider;
    [SerializeField] private TextMeshProUGUI nameText;
    public void SetMaxHealth(int health)
    {
     
        slider.maxValue = health;
        slider.value = health;
     
    }
    public void SetHealth(int health)
    {
        slider.value = health;

    } 
    public void SetName(string name)
    {
        nameText.text = name;
    }

}
