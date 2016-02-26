using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StartWaveButtonController : MonoBehaviour, IPointerClickHandler {
           
    public bool onClick = true;
    GameObject gc;
    
    void Start () {
        gc = GameObject.FindWithTag ("GameController");
    }           

    public void OnPointerClick (PointerEventData data) {
        int clickCount = 1; // single click

       
        if (onClick && clickCount == 1) {
            gc.GetComponent<GameController> ().StartWave ();
        }

    }
}
