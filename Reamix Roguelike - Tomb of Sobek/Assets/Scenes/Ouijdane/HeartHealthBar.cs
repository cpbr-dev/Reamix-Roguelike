using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealthBar : MonoBehaviour
{
    public static HeartHealthBar instance;

    [SerializeField] GameObject heartContainerPrefab;

    [SerializeField] List<GameObject> heartContainers;
    int totalHearts;
    float currentHearts;
    HeartContainer currentContainer;

    void Start()
    {
        instance = this;
        heartContainers = new List<GameObject>();
        
    }

    //HeartHealthBar.instance.SetupHearts(valueIn);
    public void SetupHearts(int heartsIn)
    {
        heartContainers.Clear();
        for(int i = transform.childCount -1; i >=0; i--)
        {  
            Destroy(transform.GetChild(i).gameObject);
        }

        totalHearts = heartsIn;
        currentHearts = (float)totalHearts;
        
        for (int i = 0; i < totalHearts; i++)
        {
            GameObject newHeart = Instantiate(heartContainerPrefab, transform);
            heartContainers.Add(newHeart);
            if(currentContainer != null)
            {
                currentContainer.next = newHeart.GetComponent<HeartContainer>();
            }
            currentContainer = newHeart.GetComponent<HeartContainer>();
        }
        currentContainer = heartContainers[0].GetComponent<HeartContainer>();

    }

    //HeartHealthBar.instance.SetCurrentHealth(valueIn);
    public void SetCurrentHealth(float health)
    {
        currentHearts = health;
        currentContainer.SetHeart(currentHearts);
        
    }

    //HeartHealthBar.instance.AddHearts(valueIn);
    public void AddHearts(float healthUp)
    {
        currentHearts += healthUp;
        if(currentHearts > totalHearts)
        {
            currentHearts = (float)totalHearts;
        }
        currentContainer.SetHeart(currentHearts);
    }

    //HeartHealthBar.instance.RemoveHearts(valueIn);
    public void RemoveHearts(float healthDown)
    {
        currentHearts -= healthDown;
        if(currentHearts < 0)
        {
            currentHearts = 0f;
        }
        currentContainer.SetHeart(currentHearts);
    }

    //HeartHealthBar.instance.AddContainer(valueIn);
    public void AddContainer()
    {
        GameObject newHeart = Instantiate(heartContainerPrefab, transform);
        currentContainer = heartContainers[heartContainers.Count - 1].GetComponent<HeartContainer>();
        heartContainers.Add(newHeart);
        

        if (currentContainer != null)
        {
            currentContainer.next = newHeart.GetComponent<HeartContainer>();
        }
    
        currentContainer = heartContainers[0].GetComponent<HeartContainer>();

        totalHearts++;
        currentHearts = totalHearts;
        SetCurrentHealth(currentHearts);
    }
}