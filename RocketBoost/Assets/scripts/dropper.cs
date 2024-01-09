using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper : MonoBehaviour
{
    Vector3 startPosition;
    Rigidbody rb;
    float fallTime;
    [SerializeField] float dropperTime;

    void Start(){
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        resetFall();
    }

    void resetFall() {
        if(fallTime <= dropperTime) {
            fallTime += Time.deltaTime;
            rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);
        } else {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
            fallTime = 0f;
        }
    }
}
