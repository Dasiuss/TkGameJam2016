using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButtonController : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick (PointerEventData data) {
        Application.Quit ();
    }
}
