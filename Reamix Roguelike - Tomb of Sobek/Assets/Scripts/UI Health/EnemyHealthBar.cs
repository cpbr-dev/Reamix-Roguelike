using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public HealthManager enemy;
    public Image fillImage;
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
        enemy = GetComponentInParent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;

        }
        if (slider.value > slider.minValue && (fillImage.enabled))
        {
            fillImage.enabled = true;
        }
        float fillValue = enemy.currHealth / enemy.maxHealth;
        if(fillValue <= slider.maxValue /3)
        {
            fillImage.color = Color.red;
        }
        else if(fillValue > slider.maxValue /3)
        {
            fillImage.color = Color.green;
        }
        slider.value = fillValue;
    }
}
