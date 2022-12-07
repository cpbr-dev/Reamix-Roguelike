using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform spawnPoint;

    [SerializeField]
    private float firePower = 20;
    [SerializeField]
    private float reloadTime;
    private bool isReloading = false;

    private GameObject currentArrow;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Fire);
        StartCoroutine(ReloadAfterTime());
    }

    public void Reload()
    {
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
        /*currentArrow.SetEnemyTag(enemyTag);*/
        isReloading = false;
    }

    public void Fire(ActivateEventArgs arg)
    {
        Debug.Log("Firing bolt");
        if (isReloading || currentArrow == null) return;
        var force = spawnPoint.TransformDirection(Vector3.forward * firePower);
        currentArrow.GetComponent<BoltBehaviour>().Fly(force);
        currentArrow = null;
        Reload();
    }

    public bool IsReady()
    {
        return (!isReloading && currentArrow != null);
    }
}
