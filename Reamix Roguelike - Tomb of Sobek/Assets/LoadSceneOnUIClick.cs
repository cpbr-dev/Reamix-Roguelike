using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{ 
public class LoadSceneOnUIClick : UIElement
{
    protected override void Awake()
    {
        base.Awake();

        //ui = this.GetComponentInParent<SkeletonUIOptions>();
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();

       
    }

    public void ChangeScene()
        {
            SceneManager.LoadScene("World");
        }
}
}
