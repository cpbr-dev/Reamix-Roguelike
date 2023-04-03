using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    [SerializeField]
    private weaponEnemy weapon;

    [SerializeField]
    private string enemyTag;

    private bool fire;

    void Start()
    {
        weapon.SetEnemyTag(enemyTag);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            fire = false;
        }

        if (fire)
        {
            weapon.Fire();
        }
    }
}
