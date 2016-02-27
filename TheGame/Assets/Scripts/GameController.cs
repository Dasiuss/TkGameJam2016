using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    private int income = 500;
    private int goldAmount = 1000;
    private Text goldText;
    private Text incomeText;
    private GameObject buttonImage;
    private float seconds;

    private float waveDuration = 10.0f;

    void Start () {
        incomeText = GameObject.FindWithTag ("IncomeText").GetComponent<Text>();
        incomeText.text = "Income: " + income;
        goldText = GameObject.FindWithTag ("GoldText").GetComponent<Text> ();
        goldText.text = "Gold: " + goldAmount;
        buttonImage = GameObject.FindWithTag ("StartWaveButton");
    }

    public void StartWave () {
        buttonImage.gameObject.SetActive (false);
        seconds = 10;
        SpawnEnemies ();
        AfterWaveUpdate ();
    }

    void AfterWaveUpdate () {
        goldAmount += income;
        buttonImage.gameObject.SetActive (true);
        Debug.Log ("Build phase");
    }

    void SpawnEnemies () {
        float time = Time.time;
        Debug.Log ("IT WORKS!");
        while (seconds > 0) {
            seconds -= Time.time-time;
            if (seconds <= 0) {
                Debug.Log ("Wave ends!");
                break;
            }
        }
    }
}