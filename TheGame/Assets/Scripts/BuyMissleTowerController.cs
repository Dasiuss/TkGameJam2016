﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuyMissleTowerController : MonoBehaviour, IPointerClickHandler {
    
    GameObject gc;

    void Start () {
        gc = GameObject.FindWithTag ("GameController");
    }

    public void OnPointerClick (PointerEventData data) {
        gc.GetComponent<GameController> ().BuyMissle ();
    }
}
