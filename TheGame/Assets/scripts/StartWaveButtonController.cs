using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StartWaveButtonController : MonoBehaviour, IPointerClickHandler {
           
    GameObject gc;
    public AudioClip clickSound;

    void Start () {
        gc = GameObject.FindWithTag ("GameController");
        this.gameObject.AddComponent<AudioSource> ();
        this.GetComponent<AudioSource> ().clip = clickSound;
    }           

    public void OnPointerClick (PointerEventData data) {
        this.GetComponent<AudioSource> ().Play ();
        gc.GetComponent<GameController> ().StartWave ();
    }
}
