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
            gc.GetComponent<GameController> ().StartWave ();
    }
}
