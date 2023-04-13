using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDisplayer : MonoBehaviour
{
    public bool hideAllAtStart = true;
    public GameObject[] icons;

    private void Start()
    {
        if (hideAllAtStart)
            HideAll();
    }

    public void DisplayIcon(int index)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(i == index);
        }
    }

    public void HideAll()
    {
        for(int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(false);
        }
    }
}
