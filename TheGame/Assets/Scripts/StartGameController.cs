using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour, IPointerClickHandler {

    public AudioClip clickSound;

    void Start () {
        this.gameObject.AddComponent<AudioSource> ();
        this.GetComponent<AudioSource> ().clip = clickSound;
    }

    public void OnPointerClick (PointerEventData data) {
        this.GetComponent<AudioSource> ().Play ();
        SceneManager.LoadScene (1);
    }

}
