using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private bool wave;
    private int income = 500;
    private int resources = 1000;

    void Start () {
        wave = false;
    }

    public void StartWave () {
        wave = true;
        Debug.Log ("IT WORKS");
    }

    void AfterWaveUpdate () {
        wave = false;
        resources += income;
    }

}
