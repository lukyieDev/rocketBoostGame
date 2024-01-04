using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    [SerializeField] TMP_Text txtTime;
    [SerializeField] TMP_Text finalTimeTxt;
    public static float time;
    public static float finalTime;

    void Start(){
        InvokeRepeating("increaseTime", 0.001f, 0.001f);
    }

    void increaseTime() {
        if (time < 0f) {
            return;
        }
        time += 0.001f;
        displayTime(time);
    }

    public void captureFinalTime() {
        finalTime = time;

        float Fminutes = Mathf.FloorToInt(finalTime / 60);
        float Fseconds = Mathf.FloorToInt(finalTime % 60);
        float Fmilesimus = Mathf.FloorToInt((finalTime * 1000) % 1000);
        finalTimeTxt.text = string.Format("{0:00}:{1:00}:{2:000}", Fminutes, Fseconds, Fmilesimus);

    }


    void displayTime(float TimeToDisplay) {
        if (TimeToDisplay < 0f) {
            time = TimeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);
        float milesimus = Mathf.FloorToInt((TimeToDisplay * 1000) % 1000);



        txtTime.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milesimus);
       
    }
}
