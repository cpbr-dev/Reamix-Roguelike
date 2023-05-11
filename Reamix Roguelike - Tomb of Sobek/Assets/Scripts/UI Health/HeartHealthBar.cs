using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealthBar : MonoBehaviour
{
    public static HeartHealthBar Instance;

    [SerializeField] GameObject heartContainerPrefab;

    [SerializeField] List<GameObject> heartContainers;
    int _totalHearts;
    float _currentHearts;
    HeartContainer _currentContainer;

    void Start()
    {
        Instance = this;
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

        _totalHearts = heartsIn;
        _currentHearts = (float)_totalHearts;
        
        for (int i = 0; i < _totalHearts; i++)
        {
            GameObject newHeart = Instantiate(heartContainerPrefab, transform);
            heartContainers.Add(newHeart);
            if(_currentContainer != null)
            {
                _currentContainer.next = newHeart.GetComponent<HeartContainer>();
            }
            _currentContainer = newHeart.GetComponent<HeartContainer>();
        }
        _currentContainer = heartContainers[0].GetComponent<HeartContainer>();

    }

    //HeartHealthBar.instance.SetCurrentHealth(valueIn);
    public void SetCurrentHealth(float health)
    {
        _currentHearts = health;
        _currentContainer.SetHeart(_currentHearts);
        
    }

    //HeartHealthBar.instance.AddHearts(valueIn);
    public void AddHearts(float healthUp)
    {
        _currentHearts += healthUp;
        if(_currentHearts > _totalHearts)
        {
            _currentHearts = (float)_totalHearts;
        }
        _currentContainer.SetHeart(_currentHearts);
    }

    //HeartHealthBar.instance.RemoveHearts(valueIn);
    public void RemoveHearts(float healthDown)
    {
        _currentHearts -= healthDown;
        if(_currentHearts < 0)
        {
            _currentHearts = 0f;
        }
        _currentContainer.SetHeart(_currentHearts);
    }

    //HeartHealthBar.instance.AddContainer(valueIn);
    public void AddContainer()
    {
        GameObject newHeart = Instantiate(heartContainerPrefab, transform);
        _currentContainer = heartContainers[heartContainers.Count - 1].GetComponent<HeartContainer>();
        heartContainers.Add(newHeart);
        

        if (_currentContainer != null)
        {
            _currentContainer.next = newHeart.GetComponent<HeartContainer>();
        }
    
        _currentContainer = heartContainers[0].GetComponent<HeartContainer>();

        _totalHearts++;
        _currentHearts = _totalHearts;
        SetCurrentHealth(_currentHearts);
    }
}