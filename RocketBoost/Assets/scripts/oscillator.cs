using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillator : MonoBehaviour{

    Vector3 startPosition;
    float tau = Mathf.PI * 2;
    float cycles;
    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;

    void Start(){
        startPosition = transform.position;
    }
    void Update(){
        period =  period < 1 ? period = 1 : period;
        cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
