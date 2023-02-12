using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public class SwitchState : MonoBehaviour
{
    public Color activate = new Color(215 / 255f, 54 / 255f, 54 / 255f, 255 / 255f);
    public Color deactivate = new Color(54 / 255f, 54 / 255f, 215 / 255f, 255 / 255f);
    public bool clicked = false;

    public void OnMouseDown()
    {
        clicked = true;
    }


    public void InitBlock(GameObject block)
    {
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", deactivate);
    }

    public void Switch()
    {
        if (this.GetComponent<MeshRenderer>().material.GetColor("_Color") == activate)
        {
            this.GetComponent<MeshRenderer>().material.SetColor("_Color", deactivate);
        }
        else
        {
            this.GetComponent<MeshRenderer>().material.SetColor("_Color", activate);
        }
    }
}

