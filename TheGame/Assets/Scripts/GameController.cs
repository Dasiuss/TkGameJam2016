using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private bool wave;
    private int income = 500;

    void Start () {
        wave = false;
    }

    void StartWave () {
        wave = true;
        btn.setActive (false);
    }


}
