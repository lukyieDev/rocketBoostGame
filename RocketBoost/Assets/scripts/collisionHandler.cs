using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionHandler : MonoBehaviour{

    void Start(){

    }
    void Update(){
        
    }

    void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag) {
            case "friend":
                Debug.Log("Amigo");
                break;
            case "Finish":
                Debug.Log("Finished");
                break;
            default:
                reloadLevel();
                break;
        }
    }
    void reloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
