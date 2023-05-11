using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartContainer : MonoBehaviour
{
    public HeartContainer next;
    [Range(0, 1)] private float _fill;

    [SerializeField] Image fillImage;
    public void SetHeart(float count)
    {
        _fill = count;
        fillImage.fillAmount = _fill;
        count--;
        if (next != null)
        {
            next.SetHeart(count);
        }
    }
}
