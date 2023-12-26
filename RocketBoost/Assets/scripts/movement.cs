using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour {

    Rigidbody rocketBody;
    AudioSource rocketAudio;
    [SerializeField] AudioClip rocketBoostSound;
    [SerializeField] float boostVelocity = 1000f;
    [SerializeField] float rotationVelocity = 250f;
    [SerializeField] public ParticleSystem jetParticle;

    // Start is called before the first frame update
    void Start() {
        rocketAudio = GetComponent<AudioSource>();
        rocketBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        processBoost();
        processRotation();
    }

    void processBoost() {

        if(Input.GetKey(KeyCode.Space)) {
            if(!rocketAudio.isPlaying) {
                rocketAudio.PlayOneShot(rocketBoostSound, 1); 
            }
            if(!jetParticle.isPlaying) {
                jetParticle.Play();    
            }
            rocketBody.AddRelativeForce(Vector3.up * boostVelocity * Time.deltaTime);
        } else {
            rocketAudio.Stop();
            jetParticle.Stop();
        }
    }
    void processRotation() {

        if(Input.GetKey(KeyCode.A)) {
            applyRotation(rotationVelocity);
        } else if(Input.GetKey(KeyCode.D)) {
            applyRotation(-rotationVelocity);
        }
    }

    void applyRotation(float rotateThisVelocity) {

        rocketBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateThisVelocity * Time.deltaTime);
        rocketBody.freezeRotation = false;
    }
}

