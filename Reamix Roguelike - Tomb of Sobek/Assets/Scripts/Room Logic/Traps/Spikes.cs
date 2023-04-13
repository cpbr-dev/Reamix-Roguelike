using System.Collections;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _originalPosition;
    private Vector3 _positionA;
    private Vector3 _positionB;
    
    private const float incrementValue = 0.7f;
    private const float upTime = 0.2f;
    private const float downTime = 1.5f;
    private const float waitTime = 2.0f;
    
    private void Start()
    {
        _transform = transform;
        _originalPosition = _transform.position;
        _positionA = _originalPosition;
        _positionB = _originalPosition + Vector3.up * incrementValue;
        StartCoroutine(CycleCoroutine());
    }
    
    private IEnumerator CycleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            var timer = 0.0f;

            while (timer < upTime)
            {
                var t = timer / upTime;
                _transform.position = Vector3.Lerp(_positionA, _positionB, t);
                timer += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(0.3f);
            
            timer = 0.0f;

            while (timer < downTime)
            {
                var t = timer / downTime;
                _transform.position = Vector3.Lerp(_positionB, _positionA, t);
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}