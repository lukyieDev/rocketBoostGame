using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionHandler : MonoBehaviour{

    movement movement;
    AudioSource rocketAudio;
    bool crashedOrFinished = false;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip winSound;

    void Start(){
        movement = GetComponent<movement>();
        rocketAudio = GetComponent<AudioSource>();
    }
    void Update(){
        
    }

    void OnCollisionEnter(Collision other) {
        if(crashedOrFinished) {return;}

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
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(crashSound, 0.3f);
        crashedOrFinished = true;
        movement.enabled = false;
        Invoke("reloadLevel", 2f);
    }

    void nextLevelSequence() {
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(winSound);
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
}
