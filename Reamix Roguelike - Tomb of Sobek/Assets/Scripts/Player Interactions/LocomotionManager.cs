using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionManager : MonoBehaviour
{
    public GameObject leftRayTeleport;

    private TeleportationProvider teleportationProvider;
    private ContinuousMoveProviderBase continuousMoveProvider;

    private ContinuousTurnProviderBase continuousTurnProvider;
    private SnapTurnProviderBase snapTurnProvider;
    // Start is called before the first frame update
    void Start()
    {
        teleportationProvider = GetComponent<TeleportationProvider>();
        continuousMoveProvider = GetComponent<ContinuousMoveProviderBase>();

        snapTurnProvider= GetComponent<ActionBasedSnapTurnProvider>();
        continuousTurnProvider = GetComponent<ActionBasedContinuousTurnProvider>();

        leftRayTeleport.SetActive(false);
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

    public void SwitchTurn(int turnValue)
    {
        if (turnValue == 0)
        {
            DisableSnap();
            EnableContinuousTurn();
        }
        else if (turnValue == 1)
        {
            DisableContinuousTurn();
            EnableSnap();
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

    private void DisableSnap()
    {
        snapTurnProvider.enabled = false;
    }
    private void EnableSnap()
    {
        snapTurnProvider.enabled = true;
    }

    private void DisableContinuousTurn()
    {
        continuousTurnProvider.enabled = false;
    }

    private void EnableContinuousTurn()
    {
        continuousTurnProvider.enabled = true;
    }
}