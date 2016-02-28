using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuyMissleTowerController : MonoBehaviour, IPointerClickHandler {
    
    GameObject gc;
    public AudioClip errorSound;
    public AudioClip buySound;

    void Start () {
        gc = GameObject.FindWithTag ("GameController");
        this.gameObject.AddComponent<AudioSource> ();
        this.GetComponent<AudioSource> ().clip = errorSound;
    }

    public void OnPointerClick (PointerEventData data) {
        gc.GetComponent<GameController> ().BuyMissle ();
    }

    public void PlayError () {
        this.GetComponent<AudioSource> ().clip = errorSound;
        this.GetComponent<AudioSource> ().Play ();
    }

    public void PlayBuy () {
        this.GetComponent<AudioSource> ().clip = buySound;
        this.GetComponent<AudioSource> ().Play ();
    }
}
