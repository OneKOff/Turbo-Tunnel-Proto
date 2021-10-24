using System;
using UnityEngine;


public class MileageStage : MonoBehaviour
{
    [SerializeField] private float _size = 100.0f;

    private float _start = default;
    private float _end = default;

    public Action OnNextStage = null; 

    void Start()
    {
        _start = transform.position.z;       
    }

    
    void Update()
    {

        if (Mathf.Abs(_end - _start) >= _size)
        {
            _start = transform.position.z;
            _end = transform.position.z;

            OnNextStage?.Invoke();
        }
        else {

            _end = transform.position.z;
        }

    }
}

