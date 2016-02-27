using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuyMissleTowerController : MonoBehaviour, IPointerClickHandler {

    public bool onClick = true;
    GameObject gc;

    void Start () {
        gc = GameObject.FindWithTag ("GameController");
    }

    public void OnPointerClick (PointerEventData data) {
        Debug.Log ("CLICK!");
        gc.GetComponent<GameController> ().BuyMissle ();
    }
}
