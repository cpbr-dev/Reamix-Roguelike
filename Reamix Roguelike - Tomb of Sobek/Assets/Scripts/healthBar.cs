using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealthSecond playerHealth;
    List<DamageHealth> hearts = new List<DamageHealth>();
    private void OnEnable()
    {
       // PlayerHealthSecond.OnPlayerDamaged += DrawHearts;
    }
    private void OnDisable()
    {
       // PlayerHealthSecond.OnPlayerDamaged -= DrawHearts;
    }
    public void Start()
    {
        DrawHearts();
    }
    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsTomake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
        for(int i=0;i<heartsTomake;i++)
        {
            CreateEmptyHeart();
        }
        for(int i=0; i<hearts.Count;i++)
        {
            int heartStatusRemaider = (int)Mathf.Clamp(playerHealth.Health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((DamageHealth.HeartStatus)heartStatusRemaider);

        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        DamageHealth heartComponent = newHeart.GetComponent<DamageHealth>();
        heartComponent.SetHeartImage(DamageHealth.HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<DamageHealth>();

    }
}
