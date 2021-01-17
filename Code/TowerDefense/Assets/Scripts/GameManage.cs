using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selectPanel = null;
    public GameObject updatePanel = null;
    public GameObject pausePanel = null;
    private static GameObject vectoryPanel = null;
    public static int totalEnemyNumber = 0;
    public static int nowEnemyNumber = 0;
    public static GameObject exitPanel = null;
    private bool pause = false;
    public TowerBase towerbase = new TowerBase();
    private Toggle tog = null;
    RaycastHit hit = new RaycastHit();
    private GameObject mainCamera;
    private Canvas canvas;
    public Text moneyText;
    public int money = 1000;
    public float timer = 1.0f;
    public Animator MoneyAnimator;



    void Start()
    {
        Time.timeScale = 1;
        mainCamera = GameObject.FindWithTag("MainCamera");
        selectPanel = transform.Find("SelectCanvas").gameObject;
        updatePanel = transform.Find("UpdateCanvas").gameObject;
        pausePanel = transform.Find("PauseCanvas").gameObject;
        exitPanel = transform.Find("ExitCanvas").gameObject;
        vectoryPanel = transform.Find("VectorCanvas").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false)
            {
                ShowPausePanel();
                return;
            }
            if (pause == true)
            {
                HidePausePanel();
                return;
            }
        }
        if (Time.timeScale == 0)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            SelectBase();
        }
        if (tog!=null && tog.isOn == true)
        {
            if (selectedTurretData != null)
            {
                if (money > 200)
                {
                    ChangeMoney(-200);
                    buildtower();
                    tog.isOn = false;
                    HideSelectPanel(hit.transform);
                }
                else
                {
                    MoneyAnimator.SetTrigger("Flicker");
                    selectedTurretData = null;
                    HideSelectPanel(hit.transform);
                }
            }
           
        }
        selectPanel.transform.rotation = mainCamera.transform.rotation;
        updatePanel.transform.rotation = mainCamera.transform.rotation;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 1.0f;
            ChangeMoney((int)((float)10*TechManage.MoneyBoost));
        }

    }
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("InitScene");
        pause = false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pause = false;
        Time.timeScale = 1;
    }
    public void ChangeMoney(int change)
    {
        if (change <0 &&TechManage.freeTrade) {


            // if (Random.Range(0, 100) <= 5)
            //{
            //}
            float discount = TechManage.getDiscount();
            change = (int)((float)change * discount); }
        money += change;
        moneyText.text = "$ " + money;
    }
    private void SelectBase()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 1000))
        {
            if (hit.transform.tag == "TowerBase")//可以建造tower
            {
                towerbase = hit.transform.GetComponent<TowerBase>();
                if (towerbase.isUpgraded == true && towerbase.turretGo!=null)
                {
                    HideSelectPanel(hit.transform);
                    ShowUpdatePanel(hit.transform);
                }
                else
                {
                    HideUpdatePanel(hit.transform);
                    ShowSelectPanel(hit.transform);
                    //towerbase = hit.transform.GetComponent<TowerBase>();
                }
                
            }
            else if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                HideSelectPanel(hit.transform);
                HideUpdatePanel(hit.transform);
            }
        }
    }
    private void ShowSelectPanel(Transform pos)
    {
        selectPanel.transform.SetParent(pos, false);
        selectPanel.transform.localPosition = new Vector3(0,20,-10);
        selectPanel.SetActive(true);
    }
    private void ShowUpdatePanel(Transform pos)
    {
        updatePanel.transform.SetParent(pos, false);
        updatePanel.transform.localPosition = new Vector3(0, 20, -10);
        updatePanel.SetActive(true);
    }
    public static void ShowExitPanel()
    {
        //exitPanel = Component.transform.Find("ExitCanvas").gameObject;

        exitPanel.SetActive(true);
        Time.timeScale = 0;
    }
    private void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }
    private void HidePausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }
    private void HideSelectPanel(Transform pos)
    {
        selectPanel.transform.SetParent(pos, false);
        selectPanel.transform.localPosition = new Vector3(0, 20, -10);
        selectPanel.SetActive(false);
    }
    private void HideUpdatePanel(Transform pos)
    {
        updatePanel.transform.SetParent(pos, false);
        updatePanel.transform.localPosition = new Vector3(0, 20, -10);
        updatePanel.SetActive(false);
    }


    public Turret acidTurretData = new Turret();
    public Turret fireTurretData = new Turret();
    public Turret gatlingTurretData = new Turret();
    public Turret mortarTurretData = new Turret();
    public Turret radarTurretData = new Turret();
    public Turret selectedTurretData = new Turret();

    public Turret acidTurretData2 = new Turret();
    public Turret fireTurretData2 = new Turret();
    public Turret gatlingTurretData2 = new Turret();
    public Turret mortarTurretData2 = new Turret();
    public Turret radarTurretData2 = new Turret();

    public Turret acidTurretData3 = new Turret();
    public Turret fireTurretData3 = new Turret();
    public Turret gatlingTurretData3 = new Turret();
    public Turret mortarTurretData3 = new Turret();
    public Turret radarTurretData3 = new Turret();

    public void buildtower()
    {
      
        towerbase.BuildTurret(selectedTurretData);
        towerbase.isUpgraded = true;
        //selectedTurretData = null;
    }
    public void OnacidSelected(bool isOn)
    {
        if (isOn)
        {
            tog = GameObject.Find("Acid").GetComponent<Toggle>();
            selectedTurretData = acidTurretData;
        }
        
    }
    public void OnfireSelected(bool isOn)
    {
        if (isOn)
        {
            tog = GameObject.Find("Fire").GetComponent<Toggle>();
            selectedTurretData = fireTurretData;
        }
    }
    public void OnagatlingSelected(bool isOn)
    {
        if (isOn)
        {
            tog = GameObject.Find("Gatling").GetComponent<Toggle>();
            selectedTurretData = gatlingTurretData;
        }
    }
    public void OnradarSelected(bool isOn)
    {
        if (isOn)
        {
            tog = GameObject.Find("Radar").GetComponent<Toggle>();
            selectedTurretData = radarTurretData;
        }
    }
    public void OnmortarSelected(bool isOn)
    {
        if (isOn)
        {
            tog = GameObject.Find("Mortar").GetComponent<Toggle>();
            selectedTurretData = mortarTurretData;
        }
    }
    public void Destroy()
    {
        if (towerbase.label == "A1" || towerbase.label == "F1" || towerbase.label == "G1" || towerbase.label == "M1" || towerbase.label == "R1")
        {
            ChangeMoney(200);
        }
        else if (towerbase.label == "A2" || towerbase.label == "F2" || towerbase.label == "G2" || towerbase.label == "M2" || towerbase.label == "R2")
        {
            ChangeMoney(200);
        }
        else if (towerbase.label == "A3" || towerbase.label == "F3" || towerbase.label == "G3" || towerbase.label == "M3" || towerbase.label == "R3")
        {
            ChangeMoney(200);
        }
        Destroy(towerbase.turretGo);
        HideUpdatePanel(hit.transform);
    }
    public void UpdateTower()
    {
        if(money < 400)
        {
            MoneyAnimator.SetTrigger("Flicker");
            HideSelectPanel(hit.transform);
            return;
        }
            if (towerbase.label == "A1")
            {
                Destroy(towerbase.turretGo);
                towerbase.BuildTurret(acidTurretData2);
                towerbase.isUpgraded = true;
                ChangeMoney(-400);
            }
            else if (towerbase.label == "F1")
            {
                Destroy(towerbase.turretGo);
                towerbase.BuildTurret(fireTurretData2);
                towerbase.isUpgraded = true;
                ChangeMoney(-400);
            }
            else if (towerbase.label == "G1")
            {
                Destroy(towerbase.turretGo);
                towerbase.BuildTurret(gatlingTurretData2);
                towerbase.isUpgraded = true;
                ChangeMoney(-400);
            }
            else if (towerbase.label == "M1")
            {
                Destroy(towerbase.turretGo);
                towerbase.BuildTurret(mortarTurretData2);
                towerbase.isUpgraded = true;
                ChangeMoney(-400);
            }
            else if (towerbase.label == "R1")
            {
                Destroy(towerbase.turretGo);
                towerbase.BuildTurret(radarTurretData2);
                towerbase.isUpgraded = true;
                ChangeMoney(-400);
            }
            else if(money < 800)
        {
            MoneyAnimator.SetTrigger("Flicker");
            HideSelectPanel(hit.transform);
            return;
        }
        else if (towerbase.label == "A2")
        {
            Destroy(towerbase.turretGo);
            towerbase.BuildTurret(acidTurretData3);
            towerbase.isUpgraded = true;
            ChangeMoney(-800);
        }
        else if (towerbase.label == "F2")
        {
            Destroy(towerbase.turretGo);
            towerbase.BuildTurret(fireTurretData3);
            towerbase.isUpgraded = true;
            ChangeMoney(-800);
        }
        else if (towerbase.label == "G2")
        {
            Destroy(towerbase.turretGo);
            towerbase.BuildTurret(gatlingTurretData3);
            towerbase.isUpgraded = true;
            ChangeMoney(-800);
        }
        else if (towerbase.label == "M2")
        {
            Destroy(towerbase.turretGo);
            towerbase.BuildTurret(mortarTurretData3);
            towerbase.isUpgraded = true;
            ChangeMoney(-800);
        }
        else if (towerbase.label == "R2")
        {
            Destroy(towerbase.turretGo);
            towerbase.BuildTurret(radarTurretData3);
            towerbase.isUpgraded = true;
            ChangeMoney(-800);
        }
        else
        {
            
        }
        HideUpdatePanel(hit.transform);
    }

    public static void IsEnd(int nowEnemyNumber) {

        if (nowEnemyNumber ==totalEnemyNumber )
        {
            Debug.Log("vectory");
            vectoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public static void IsEnd()
    {

            Debug.Log("vectory");
            vectoryPanel.SetActive(true);
            Time.timeScale = 0;
      
    }

}
