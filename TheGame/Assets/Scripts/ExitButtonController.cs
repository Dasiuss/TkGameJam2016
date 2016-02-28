using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButtonController : MonoBehaviour, IPointerClickHandler {

    public AudioClip clickSound;

    void Start () {
        this.gameObject.AddComponent<AudioSource> ();
        this.GetComponent<AudioSource> ().clip = clickSound;
    }

    public void OnPointerClick (PointerEventData data) {
        this.GetComponent<AudioSource> ().Play ();
        Application.Quit ();
    }
}
