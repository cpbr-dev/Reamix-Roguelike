using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartContainer : MonoBehaviour
{
    public HeartContainer next;
    public HealthManager healthMan;
    [Range(0, 1)] private float fill;

    [SerializeField] Image fillImage;
    public void SetHeart(float count)
    {
        fill = count;
        fillImage.fillAmount = fill;
        count--;
        if (next != null)
        {
            next.SetHeart(count);
        }
    }
}
