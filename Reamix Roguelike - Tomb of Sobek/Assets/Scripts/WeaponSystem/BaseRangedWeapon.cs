using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseRangedWeapon : MonoBehaviour
{
    [SerializeField] private Transform shotOrigin;
    private float nextTimeToFire = 0f;
    [SerializeField] protected RangedWepSO weaponSo;

    private bool CheckFireRate()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / weaponSo.fireRate);
            return true;
        }

        return false;
    }
    
    public void ShootingLogic()
    {
        switch (weaponSo.shotType)
        {
            case RangedWepSO.ShotType.Auto:
            {
                if (CheckFireRate())
                {
                    InstanceProjectile(shotOrigin);
                }

                break;
            }
            case RangedWepSO.ShotType.Single:
                InstanceProjectile(shotOrigin);
                break;
        }
    }

    private GameObject InstanceProjectile(Transform origin)
    {
        GameObject projectile = Instantiate(
            weaponSo.projectilePrefab,
            origin.position,
            origin.rotation,
            null
        );
        
        return projectile;
    }

    public abstract void Shoot();
}
