using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick (PointerEventData data) {
        SceneManager.LoadScene (1);
    }
}
