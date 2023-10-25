using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour{

    Rigidbody rocketBody;
    MeshRenderer rocketMesh;
    [SerializeField] float boostVelocity = 1000f;
    [SerializeField] float rotationVelocity = 0.5f;

    // Start is called before the first frame update
    void Start() {
        rocketBody = GetComponent<Rigidbody>();
        rocketMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update(){
        processBoost();    
        processRotation();
    } 
    
    void processBoost() {

        if (Input.GetKey(KeyCode.Space)) {

            rocketBody.AddRelativeForce(Vector3.up * boostVelocity * Time.deltaTime);

        }
    }
    void processRotation() {

        if (Input.GetKey(KeyCode.A)) {
            applyRotation(rotationVelocity);
        } else if (Input.GetKey(KeyCode.D)) {
            applyRotation(-rotationVelocity);
        }
    }

    void applyRotation(float rotateThisVelocity) {

        rocketBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateThisVelocity * Time.deltaTime);
        rocketBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision other) { 
        if (other.gameObject.tag == "ground"){
            rocketBody.isKinematic = true;
            rotationVelocity = 0;
        }
    }
}

