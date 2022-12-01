using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Attach : MonoBehaviour
{
    // Start is called before the first frame update
    private Interactable interactable;
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }
    private void OnHandHoverBegin( Hand hand)
    {
        hand.ShowGrabHint();

    }
    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    private void OnHandHoverUpdate( Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);
        //Grabe the object
        if(interactable.attachedToHand == null && grabType!=GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }
        //Release
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
