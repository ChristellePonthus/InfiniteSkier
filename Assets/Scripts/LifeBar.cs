using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxLifepoints(float maxLifepoints)
    {
        slider.maxValue = maxLifepoints;
        slider.value = maxLifepoints;
    }

    public void SetLifepoints(float lifepoints)
    {
        slider.value = lifepoints;
    }
}
