using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RangedWep SO", order = 1)]
public class RangedWepSO : ScriptableObject, ISerializationCallbackReceiver
{
    public string wepName;
    public float fireRate;
    public ShotType shotType;
    [SerializeField] public GameObject projectilePrefab;
    void Init()
    {
        
    }

    public void OnBeforeSerialize()
    {
        Init();
    }

    public void OnAfterDeserialize()
    {
        
    }
    
    public enum ShotType {
        Auto,
        Single,
        Burst
    }
}
