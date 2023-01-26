using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionManager : MonoBehaviour
{
    public GameObject leftRayTeleport;

    private TeleportationProvider teleportationProvider;
    private ContinuousMoveProviderBase continuousMoveProvider;
    // Start is called before the first frame update
    void Start()
    {
        teleportationProvider = GetComponent<TeleportationProvider>();
        continuousMoveProvider = GetComponent<ContinuousMoveProviderBase>();
    }

    public void SwitchLocomotion(int locomotionValue)
    {
        if(locomotionValue == 0)
        {
            DisableTeleport();
            EnableContinuous();
        }
        else if (locomotionValue == 1)
        {
            DisableContinuous();
            EnableTeleport();
        }
    }

    private void DisableTeleport()
    {
        leftRayTeleport.SetActive(false);
        teleportationProvider.enabled = false;
    }

    private void EnableTeleport()
    {
        leftRayTeleport.SetActive(true);
        teleportationProvider.enabled = true;
    }

    private void DisableContinuous()
    {
        continuousMoveProvider.enabled = false;
    }

    private void EnableContinuous()
    {
        continuousMoveProvider.enabled = true;
    }
}