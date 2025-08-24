using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;

    // Call this to set health (0 to 1 for percent, or set max value for absolute)
    public void SetHealth(float value)
    {
        healthSlider.value = value;
    }

    public void SetMaxHealth(float max)
    {
        healthSlider.maxValue = max;
    }
}