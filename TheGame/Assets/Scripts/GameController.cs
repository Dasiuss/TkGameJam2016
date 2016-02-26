using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private bool wave;
    private int income = 500;
    private int goldAmount = 1000;
    private Text goldText;
    private Text incomeText;
    private GameObject buttonImage;

    private float waveDuration = 10.0f;

    void Start () {
        wave = false;
        incomeText = GameObject.FindWithTag ("IncomeText").GetComponent<Text>();
        incomeText.text = "Income: " + income;
        goldText = GameObject.FindWithTag ("GoldText").GetComponent<Text> ();
        goldText.text = "Gold: " + goldAmount;
        buttonImage = GameObject.FindWithTag ("StartWaveButton");//.GetComponent<Image> ();
    }

    public IEnumerator StartWave () {
        wave = true;
        buttonImage.gameObject.SetActive (false);
        SpawnEnemies ();
        yield return new WaitForSeconds (waveDuration);
        AfterWaveUpdate ();
    }

    void AfterWaveUpdate () {
        wave = false;
        goldAmount += income;
        buttonImage.gameObject.SetActive (true);
    }

    void SpawnEnemies () {
        Debug.Log ("IT WORKS!");
    }
}