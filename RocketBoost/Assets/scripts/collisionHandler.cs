using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionHandler : MonoBehaviour{

    movement movement;
    AudioSource rocketAudio;
    bool crashedOrFinished = false;
    bool collisionStatus = false;
    Light rocketLantern;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem winParticles;

    void Start(){
        movement = GetComponent<movement>();
        rocketAudio = GetComponent<AudioSource>();
        rocketLantern = transform.Find("rocketFarolLight").GetComponent<Light>();
    }
    void Update(){
        loadDebugKeys();
    }

    void OnCollisionEnter(Collision other) {
        if(crashedOrFinished || collisionStatus) {return;}

        switch(other.gameObject.tag) {
            case "friend":
                Debug.Log("Amigo");
                break;
            case "Finish":
                nextLevelSequence();
                break;
            default:
                crashSequence();
                break;
        }
    }

    void crashSequence() {
        movement.jetParticle.Stop();
        rocketAudio.Stop();
        crashParticles.Play();
        rocketAudio.PlayOneShot(crashSound, 0.3f);
        crashedOrFinished = true;
        movement.enabled = false;
        Invoke("reloadLevel", 2f);
    }

    void nextLevelSequence() {
        movement.jetParticle.Stop();
        rocketAudio.Stop();
        winParticles.Play();
        rocketAudio.PlayOneShot(winSound);
        crashedOrFinished = true;
        movement.enabled = false;
        Invoke("loadNextLevel", 2f);
    }

    void reloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void loadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int allScenesQuantity = SceneManager.sceneCountInBuildSettings;

        if(nextSceneIndex < allScenesQuantity) {
            SceneManager.LoadScene(nextSceneIndex);
        } else {
            SceneManager.LoadScene(0);
        }
        
    }

    void loadDebugKeys() {
        if(Input.GetKeyUp(KeyCode.L)) {
            loadNextLevel();
        } else if(Input.GetKeyUp(KeyCode.C)) {
            collisionStatus = !collisionStatus;
        } else if(Input.GetKeyUp(KeyCode.R)) {
            reloadLevel();
        } else if( Input.GetKeyUp(KeyCode.F)) {
            rocketLantern.enabled = !rocketLantern.enabled;
        }
    }
}
