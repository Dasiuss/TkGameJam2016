using UnityEngine;
using System.Collections;

public class MusicManagerCtrl : MonoBehaviour {

    public AudioClip castleDestroyedSound;
    void Start () {
        this.gameObject.AddComponent<AudioSource> ();
        this.GetComponent<AudioSource> ().clip = castleDestroyedSound;
    }
	
	public void PlayDestroy () {
        this.GetComponent<AudioSource> ().Play ();
    }
}
