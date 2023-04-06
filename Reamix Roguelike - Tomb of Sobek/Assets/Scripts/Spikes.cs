using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spikes : MonoBehaviour
{

    [SerializeField] private GameObject spikes;
    [SerializeField] private float delay = 2f;
    [SerializeField] private float waitingTime = 2f;

    private Vector3 _spikePosition;
    private Vector3 _endPosition;
    private Vector3 _startPosition;

    private bool running = false;
    private void Start()
    {
        _spikePosition = spikes.transform.position;
        _startPosition = _spikePosition;
        _endPosition = _startPosition + (spikes.transform.up * 1.5f);
    }


    private void Update()
    {
        if (!running)
        {
            SpikeLoop();
        }
    }

    private void SpikeLoop()
    {
        running = true;
        
        float elapsedTime = 0;
        while (elapsedTime < delay)
        {
            Debug.Log("Moving spike up.");
            _spikePosition = Vector3.Lerp(_startPosition, _endPosition, elapsedTime / 0.5f) ;
            elapsedTime += Time.deltaTime;
        }
        
        elapsedTime = 0;
        while (elapsedTime < delay)
        {
            Debug.Log("Moving spike down.");

            _spikePosition = Vector3.Lerp(_endPosition, _startPosition, elapsedTime / delay) ;
            elapsedTime += Time.deltaTime;
        }
        
        elapsedTime = 0;
        while (elapsedTime < waitingTime)
        {
            Debug.Log("Waiting...");

            elapsedTime += Time.deltaTime;
        }

        running = false;
    }


}
