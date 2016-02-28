using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    
    private int income = 500;
    private int goldAmount = 1000;
    private Text goldText;
    private Text incomeText;
    private Text hpinf;
    private GameObject castle;
    private GameObject buttonImage;
    private GameObject spellPanel;
    private GameObject monsterSpawner;
    private GameObject buyTowerPnl;
    private GameObject [] spellsIcons = new GameObject [3];
    private bool wave;

    private int[] availableSpells = new int[3] { 0, 0, 0 };

    private GameObject losemsg;
    private bool [] spells = new bool [3];
    

    private float spawnEnemiesCallRate = 0.5f;
    private float spawnEnemiesLastCall = 0;

    private float startTime;
    private float seconds;
    private float time;
    private float waveDuration = 10.0f;

    public GameObject missleTowerPrefab;
    public GameObject freezeTowerPrefab;
    public GameObject sniperTowerPrefab;
    public AudioClip buildMusic;
    public AudioClip waveMusic;
    public float volume;
    public GameObject spell1;
    public GameObject spell2;
    public GameObject spell3;

    void Start () {
        losemsg = GameObject.Find ("LoseMessage");
        losemsg.SetActive (false);
        wave = false;
        incomeText = GameObject.FindWithTag ("IncomeText").GetComponent<Text>();
        incomeText.text = "Income: " + income;
        goldText = GameObject.FindWithTag ("GoldText").GetComponent<Text> ();
        goldText.text = "Gold: " + goldAmount;
        buttonImage = GameObject.FindWithTag ("StartWaveButton");
        spellPanel = GameObject.Find ("SpellPanel");
        spellPanel.gameObject.SetActive (false);
        buyTowerPnl = GameObject.Find ("TowerPanel");
        monsterSpawner = GameObject.Find ("MonsterSpawner");
        SetBuyTowerPanel ();
        this.gameObject.AddComponent<AudioSource> ();
        this.GetComponent<AudioSource> ().clip = buildMusic;
        this.GetComponent<AudioSource> ().volume = volume;
        this.GetComponent<AudioSource> ().Play ();
        castle = GameObject.Find ("Castle");
        Debug.Log(castle);
        hpinf = GameObject.Find ("HpInfo").GetComponent<Text>();
    }

    void Update () {
        hpinf.text = "Castle HP: " + castle.GetComponent<Assets.scripts.Castle> ().hp;
        time = Time.time;
        seconds = time - startTime;
        if (seconds > waveDuration && wave) {
            AfterWaveUpdate ();
        }
        if (wave && time - spawnEnemiesLastCall > spawnEnemiesCallRate) {
            spawnEnemiesLastCall = time;
            SpawnEnemies ();
            for (int i = 0; i < 3; i++) {
                if (availableSpells [i] > 0) {
                    spellsIcons [i].SetActive (true);
                }//else {
                  //  spellsIcons [i].SetActive(false);
                //}
            }
        }
    }

    void SetBuyTowerPanel () {
        Text mthp = GameObject.Find ("MtHP").GetComponent<Text> ();
        Text mtdmg = GameObject.Find ("MtDmg").GetComponent<Text> ();
        Text mtfr = GameObject.Find ("MtFr").GetComponent<Text> ();
        mthp.text = "HP: " + missleTowerPrefab.GetComponent<Assets.scripts.Building> ().hp;
        mtdmg.text = "Dmg: " + missleTowerPrefab.GetComponent<TowerScript> ().damage;
        mtfr.text = "FR: " + missleTowerPrefab.GetComponent<TowerScript> ().fireRate;


        Text fthp = GameObject.Find ("FtHP").GetComponent<Text> ();
        Text ftdmg = GameObject.Find ("FtDmg").GetComponent<Text> ();
        Text ftfr = GameObject.Find ("FtFr").GetComponent<Text> ();
        fthp.text = "HP: " + freezeTowerPrefab.GetComponent<TowerScript> ().hp;
        ftdmg.text = "Dmg: " + freezeTowerPrefab.GetComponent<TowerScript> ().damage;
        ftfr.text = "FR: " + freezeTowerPrefab.GetComponent<TowerScript> ().fireRate;


        Text sthp = GameObject.Find ("StHP").GetComponent<Text> ();
        Text stdmg = GameObject.Find ("StDmg").GetComponent<Text> ();
        Text stfr = GameObject.Find ("StFr").GetComponent<Text> ();
        sthp.text = "HP: " + sniperTowerPrefab.GetComponent<TowerScript> ().hp;
        stdmg.text = "Dmg: " + sniperTowerPrefab.GetComponent<TowerScript> ().damage;
        stfr.text = "Fr: " + sniperTowerPrefab.GetComponent<TowerScript> ().fireRate;
    }

    public void StartWave () {
        this.GetComponent<AudioSource> ().Pause ();
        this.GetComponent<AudioSource> ().clip = waveMusic;
        this.GetComponent<AudioSource> ().Play ();
        buttonImage.gameObject.SetActive (false);
        seconds = 10;
        startTime = Time.time;
        wave = true;
        spellPanel.SetActive (true);
        buyTowerPnl.SetActive (false);
        FindSpellsIcons ();
    }

    void AfterWaveUpdate () {
        wave = false;
        this.GetComponent<AudioSource> ().Pause ();
        this.GetComponent<AudioSource> ().clip = buildMusic;
        this.GetComponent<AudioSource> ().Play ();
        goldAmount += income;
        goldText.text = "Gold: " + goldAmount;
        buttonImage.gameObject.SetActive (true);
        spellPanel.gameObject.SetActive (false);
        buyTowerPnl.SetActive (true);
        Debug.Log ("Build phase");
        GameObject [] enemies = GameObject.FindGameObjectsWithTag ("enemy");
        foreach (GameObject e in enemies) {
            Destroy (e);
        };
     //   for (int i = 0; i < 3; i++) {
     //       spells [i] = false;
     //   }
    }

    void TextUpdate()
    {
        goldText.text = "Gold: " + goldAmount;
        incomeText = GameObject.FindWithTag("IncomeText").GetComponent<Text>();
        incomeText.text = "Income: " + income;
    }

    void SpawnEnemies () {
        monsterSpawner.GetComponent<MonsterSpawnerScript> ().SpawnMob ();
        
    }
    
    public void addSpell(object spellNumber)
    {
        availableSpells[(int) spellNumber]++;
    }

    void FindSpellsIcons () {
        spellsIcons [0] = GameObject.Find ("ChaosSpell");
        spellsIcons [0].SetActive (false);
        spellsIcons [1] = GameObject.Find ("FreezeSpell");
        spellsIcons [1].SetActive (false);
        spellsIcons [2] = GameObject.Find ("IncomeSpell");
        spellsIcons [2].SetActive (false);
    }

    void AddGoldForAKill(object gold)
    {
        this.goldAmount += (int)gold;
    }

    public void BuyMissle () {
        if (missleTowerPrefab.GetComponent<TowerScript> ().cost <= goldAmount) {
            GameObject.Find("BuyMissleTower").GetComponent<BuyMissleTowerController>().SendMessage ("PlayBuy", null);
            GameObject mtower = (GameObject)Instantiate(missleTowerPrefab, new Vector3(10, -78.91f, 10), missleTowerPrefab.transform.rotation);

            mtower.SendMessage ("SetMovable", true);
            goldAmount -= missleTowerPrefab.GetComponent<TowerScript> ().cost;
            TextUpdate();
        } else {
            GameObject buyMissleTower = GameObject.Find ("BuyMissleTower");
            BuyMissleTowerController bmtc = buyMissleTower.GetComponent<BuyMissleTowerController> ();
            bmtc.SendMessage ("PlayError", null);
        }
    }

    public void BuyFreeze () {
        if (freezeTowerPrefab.GetComponent<FreezTowerController> ().cost <= goldAmount) {
            GameObject.Find ("BuyFreezeTower").GetComponent<BuyFreezeTowerController> ().SendMessage ("PlayBuy", null);
            GameObject mtower = (GameObject)Instantiate(freezeTowerPrefab, new Vector3(10, -78.91f, 10), freezeTowerPrefab.transform.rotation);

            mtower.SendMessage ("SetMovable", true);
            goldAmount -= freezeTowerPrefab.GetComponent<FreezTowerController> ().cost;
            TextUpdate();
        } else {
            GameObject buyFreezeTower = GameObject.Find ("BuyFreezeTower");
            BuyFreezeTowerController bftc = buyFreezeTower.GetComponent<BuyFreezeTowerController> ();
            bftc.SendMessage ("PlayError", null);
        }
    }

    public void BuySniper () {
        if (sniperTowerPrefab.GetComponent<TowerScript> ().cost <= goldAmount) {
            
            GameObject.Find ("BuySniperTower").GetComponent<BuySniperTowerController> ().SendMessage ("PlayBuy", null);
            GameObject mtower = (GameObject)Instantiate(sniperTowerPrefab, new Vector3(10, -78.91f, 10), sniperTowerPrefab.transform.rotation);
            mtower.SendMessage ("SetMovable", true);
            goldAmount -= sniperTowerPrefab.GetComponent<TowerScript> ().cost;
            TextUpdate();
        } else {
            GameObject buySniperTower = GameObject.Find ("BuySniperTower");
            BuySniperTowerController bstc = buySniperTower.GetComponent<BuySniperTowerController> ();
            bstc.SendMessage ("PlayError", null);
        }
    }

    public void EndGame () {
        this.GetComponent<AudioSource> ().Pause ();
        wave = false;
        hpinf.text = "Castle HP: 0";
        losemsg.SetActive (true);
    }

    public void IncIncome (object o) {
        income += (int)o;
        availableSpells[2]--;
        TextUpdate();
    }
}